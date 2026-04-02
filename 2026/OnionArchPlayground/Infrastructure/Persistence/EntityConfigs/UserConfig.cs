using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Infrastructure.Persistence.EntityConfigs;

public sealed class UserConfig : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> b)
	{
		b.HasKey(x => x.Id);
		b.Property(x => x.Email).HasMaxLength(256).IsRequired();
		b.HasIndex(x => x.Email).IsUnique();
		b.Property(x => x.PasswordHash).IsRequired();
		b.Property(x => x.Role).HasMaxLength(32).IsRequired();

		b.HasMany(x => x.RefreshTokens)
		 .WithOne(x => x.User)
		 .HasForeignKey(x => x.UserId);
	}
}
