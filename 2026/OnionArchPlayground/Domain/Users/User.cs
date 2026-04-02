using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users;

public sealed class User
{
	public Guid Id { get; set; }
	public required string Email { get; set; }      // normalized uniqueness handled in DB/config
	public required string PasswordHash { get; set; }
	public required string Role { get; set; } = "User";
	public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	public List<RefreshToken> RefreshTokens { get; set; } = new();
}

