using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Abstractions;

public interface IJwtTokenService
{
	(string token, DateTimeOffset expiresAt) CreateAccessToken(Guid userId, string email, string role);
	(string refreshToken, string refreshTokenHash, DateTimeOffset expiresAt) CreateRefreshToken();
	string HashRefreshToken(string refreshToken);
}
