using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.EntityConfigs;

public sealed class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
{
	public void Configure(EntityTypeBuilder<RefreshToken> b)
	{
		b.HasKey(x => x.Id);
		b.Property(x => x.TokenHash).HasMaxLength(128).IsRequired();
		b.HasIndex(x => x.TokenHash).IsUnique();
		b.Property(x => x.ReplacedByTokenHash).HasMaxLength(128);
	}
}
