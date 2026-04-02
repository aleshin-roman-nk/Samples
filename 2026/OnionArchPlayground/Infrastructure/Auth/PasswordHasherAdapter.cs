using Application.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Auth;

public sealed class PasswordHasherAdapter: IPasswordHasher
{
	private readonly PasswordHasher<string> _hasher = new();

	public string Hash(string password) =>
		_hasher.HashPassword("user", password);

	public bool Verify(string passwordHash, string password) =>
		_hasher.VerifyHashedPassword("user", passwordHash, password) == PasswordVerificationResult.Success;
}
