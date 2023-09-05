using Microsoft.EntityFrameworkCore;
using PlayEF_Sqlite.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayEF_Sqlite
{
	internal class AppData: DbContext
	{
		string _path;

		public AppData() : base()
		//public AppData(DbContextOptions<AppData> options) : base(options)
		{
			_path = "data.sqlite";

			//_path = path;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite($"Filename={_path}");

			//optionsBuilder.LogTo(Console.WriteLine);
			//optionsBuilder.EnableSensitiveDataLogging(true);
		}

		public DbSet<Card> Cards { get; set; }
		public DbSet<Thought> Thoughts { get; set; }
	}
}
