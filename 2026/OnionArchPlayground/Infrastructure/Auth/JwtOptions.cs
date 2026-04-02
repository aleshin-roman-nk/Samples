using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Auth;

public sealed class JwtOptions
{
	public const string SectionName = "Jwt";

	public required string Issuer { get; init; }
	public required string Audience { get; init; }
	public required string SigningKey { get; init; } // 32+ chars минимум
	public int AccessTokenMinutes { get; init; } = 15;
	public int RefreshTokenDays { get; init; } = 30;
}
