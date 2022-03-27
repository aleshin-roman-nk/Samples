using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyLesson
{
    internal class AppData: DbContext
    {
        string _path;

        public AppData(string path)
        {
            _path = path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_path}");
        }

        public DbSet<matrix> matrices { get; set; }
        public DbSet<word> words { get; set; }
    }
}
