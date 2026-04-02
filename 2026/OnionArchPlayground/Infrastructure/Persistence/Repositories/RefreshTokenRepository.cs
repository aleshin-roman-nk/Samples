using Application.Abstractions;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
	private readonly AppDbContext _db;
	public RefreshTokenRepository(AppDbContext db) => _db = db;

	public Task AddAsync(RefreshToken token, CancellationToken ct) =>
		_db.RefreshTokens.AddAsync(token, ct).AsTask();

	public Task<RefreshToken?> FindActiveByHashAsync(string tokenHash, CancellationToken ct) =>
		_db.RefreshTokens.FirstOrDefaultAsync(x =>
			x.TokenHash == tokenHash &&
			x.RevokedAt == null &&
			x.ExpiresAt > DateTimeOffset.UtcNow, ct);

	public Task SaveChangesAsync(CancellationToken ct) => _db.SaveChangesAsync(ct);
}