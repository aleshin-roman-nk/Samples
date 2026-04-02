using Application.Abstractions;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Auth;

public class AuthService
{
	private readonly IUserRepository _users;
	private readonly IRefreshTokenRepository _refreshTokens;
	private readonly IPasswordHasher _hasher;
	private readonly IJwtTokenService _jwt;

	public AuthService(
		IUserRepository users,
		IRefreshTokenRepository refreshTokens,
		IPasswordHasher hasher,
		IJwtTokenService jwt)
	{
		_users = users;
		_refreshTokens = refreshTokens;
		_hasher = hasher;
		_jwt = jwt;
	}

	public async Task RegisterAsync(RegisterRequest req, CancellationToken ct)
	{
		var email = NormalizeEmail(req.Email);

		var exists = await _users.FindByEmailAsync(email, ct);
		if (exists is not null) throw new InvalidOperationException("Email already registered.");

		var user = new User
		{
			Id = Guid.NewGuid(),
			Email = email,
			PasswordHash = _hasher.Hash(req.Password),
			Role = "User"
		};

		await _users.AddAsync(user, ct);
		await _users.SaveChangesAsync(ct);
	}

	public async Task<AuthResponse> LoginAsync(LoginRequest req, CancellationToken ct)
	{
		var email = NormalizeEmail(req.Email);
		var user = await _users.FindByEmailAsync(email, ct)
				   ?? throw new InvalidOperationException("Invalid credentials.");

		if (!_hasher.Verify(user.PasswordHash, req.Password))
			throw new InvalidOperationException("Invalid credentials.");

		return await IssueTokensAsync(user, ct);
	}

	public async Task<AuthResponse> RefreshAsync(RefreshRequest req, CancellationToken ct)
	{
		// 1) хэшируем то, что пришло
		var incomingHash = _jwt.HashRefreshToken(req.RefreshToken);

		// 2) ищем активный токен
		var stored = await _refreshTokens.FindActiveByHashAsync(incomingHash, ct)
					 ?? throw new InvalidOperationException("Invalid refresh token.");

		// 3) поднимаем пользователя
		var user = await _users.GetByIdAsync(stored.UserId, ct)
				   ?? throw new InvalidOperationException("User not found.");

		// 4) rotate refresh token
		stored.RevokedAt = DateTimeOffset.UtcNow;

		var (newRefresh, newRefreshHash, refreshExp) = _jwt.CreateRefreshToken();
		stored.ReplacedByTokenHash = newRefreshHash;

		await _refreshTokens.AddAsync(new RefreshToken
		{
			Id = Guid.NewGuid(),
			UserId = user.Id,
			TokenHash = newRefreshHash,
			ExpiresAt = refreshExp
		}, ct);

		await _refreshTokens.SaveChangesAsync(ct);

		// 5) новый access
		var (access, accessExp) = _jwt.CreateAccessToken(user.Id, user.Email, user.Role);

		return new AuthResponse(access, accessExp, newRefresh, refreshExp);
	}

	private async Task<AuthResponse> IssueTokensAsync(User user, CancellationToken ct)
	{
		var (access, accessExp) = _jwt.CreateAccessToken(user.Id, user.Email, user.Role);
		var (refresh, refreshHash, refreshExp) = _jwt.CreateRefreshToken();

		await _refreshTokens.AddAsync(new RefreshToken
		{
			Id = Guid.NewGuid(),
			UserId = user.Id,
			TokenHash = refreshHash,
			ExpiresAt = refreshExp
		}, ct);

		await _refreshTokens.SaveChangesAsync(ct);

		return new AuthResponse(access, accessExp, refresh, refreshExp);
	}

	private static string NormalizeEmail(string email) => email.Trim().ToLowerInvariant();
}
