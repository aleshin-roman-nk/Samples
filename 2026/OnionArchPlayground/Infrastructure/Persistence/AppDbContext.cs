using Domain.Users;
using Infrastructure.Persistence.EntityConfigs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence;

public class AppDbContext: DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<User> Users => Set<User>();
	public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
	}
}
