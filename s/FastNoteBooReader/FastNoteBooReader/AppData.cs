using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoteBooReader
{
    internal class AppData: DbContext
    {
        string _path;

        public AppData(string path) : base()
        {
            _path = path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_path}");
        }

        public DbSet<FastNote> table1 { get; set; }
    }
}
