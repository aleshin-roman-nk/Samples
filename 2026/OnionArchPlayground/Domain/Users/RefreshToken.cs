using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users;

public sealed class RefreshToken
{
	public Guid Id { get; set; }
	public Guid UserId { get; set; }

	public required string TokenHash { get; set; }   // хранить только хэш
	public DateTimeOffset ExpiresAt { get; set; }
	public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

	public DateTimeOffset? RevokedAt { get; set; }
	public string? ReplacedByTokenHash { get; set; }
	public bool IsActive => RevokedAt is null && DateTimeOffset.UtcNow < ExpiresAt;
	public User? User { get; set; }
}

