using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
	{
		var cs = config.GetConnectionString("Default");

		services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(cs));

		// Репозитории/UnitOfWork
		// services.AddScoped<IUnitOfWork, UnitOfWork>();
		// services.AddScoped<IFlashcardRepository, FlashcardRepository>();

		return services;
	}
}
