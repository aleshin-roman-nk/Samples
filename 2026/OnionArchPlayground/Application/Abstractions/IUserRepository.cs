using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Abstractions;

public interface IUserRepository
{
	Task<User?> FindByEmailAsync(string email, CancellationToken ct);
	Task<User?> GetByIdAsync(Guid id, CancellationToken ct);
	Task AddAsync(User user, CancellationToken ct);
	Task SaveChangesAsync(CancellationToken ct);
}