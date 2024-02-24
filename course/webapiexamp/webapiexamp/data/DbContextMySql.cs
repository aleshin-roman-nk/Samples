using Microsoft.EntityFrameworkCore;
using System.Configuration;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace webapiexamp.data
{
	public class DbContextMySql: DbContext
	{
		//private readonly string _connectionStringSettings;

		//public DbContextMySql(IConfiguration config)
		public DbContextMySql(DbContextOptions<DbContextMySql> options) : base(options)
		{
			//_connectionStringSettings = config.GetConnectionString("LocalMySqlConnection");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//if (!optionsBuilder.IsConfigured)
			//{
			//	optionsBuilder.UseMySql(_connectionStringSettings,
			//		new MySqlServerVersion(new Version(8, 0, 25)));
			//}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.HasDefaultSchema("mycourse");

			modelBuilder.Entity<Computer>()
			.ToTable("Computers", "mycourse");
		}

		public DbSet<Computer> Computers { get; set; }
	}
}
