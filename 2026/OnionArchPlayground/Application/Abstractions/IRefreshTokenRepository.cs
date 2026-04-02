using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Abstractions;

public interface IRefreshTokenRepository
{
	Task AddAsync(RefreshToken token, CancellationToken ct);
	Task<RefreshToken?> FindActiveByHashAsync(string tokenHash, CancellationToken ct);
	Task SaveChangesAsync(CancellationToken ct);
}