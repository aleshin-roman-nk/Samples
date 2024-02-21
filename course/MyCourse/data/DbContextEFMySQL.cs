using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class DbContextEFMySQL : DbContext
{

        private IConfiguration _config;

        public DbContextEFMySQL(IConfiguration config)
        {
            _config = config;
            Database.EnsureCreated();
        }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_config.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 25)));
        }

        //        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasDefaultSchema("mycourse");

        modelBuilder.Entity<Computer>()
        .ToTable("Computers", "mycourse");


        //        base.OnModelCreating(modelBuilder);
    }


    public DbSet<Computer> Computers { get; set; }
}