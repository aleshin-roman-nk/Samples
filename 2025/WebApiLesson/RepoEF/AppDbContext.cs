using Microsoft.EntityFrameworkCore;
using WebApiLesson.ImplementRepo.EF.Entities;

namespace WebApiLesson.ImplementRepo.EF
{
	public class AppDbContext: DbContext
	{
		public DbSet<AnimalDb> Animals => Set<AnimalDb>();

		public AppDbContext(DbContextOptions opt): base(opt) { }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
		}
	}
}
