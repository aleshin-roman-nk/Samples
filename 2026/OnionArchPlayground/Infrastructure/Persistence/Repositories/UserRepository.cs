using Application.Abstractions;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository: IUserRepository
{
	private readonly AppDbContext _db;
	public UserRepository(AppDbContext db) => _db = db;
	public Task<User?> FindByEmailAsync(string email, CancellationToken ct) =>
		_db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email, ct);
	public Task<User?> GetByIdAsync(Guid id, CancellationToken ct) =>
		_db.Users.FirstOrDefaultAsync(x => x.Id == id, ct);
	public Task AddAsync(User user, CancellationToken ct) =>
		_db.Users.AddAsync(user, ct).AsTask();
	public Task SaveChangesAsync(CancellationToken ct) => _db.SaveChangesAsync(ct);
}
