using EFCoreRepo.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRepo
{
	public class AppData: DbContext
	{
		public DbSet<AnimalDb> Animals { get; set; }

		public AppData(DbContextOptions opt) : base(opt) { }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
		}
	}
}
