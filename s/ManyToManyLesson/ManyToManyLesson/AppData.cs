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
            //optionsBuilder.UseSqlite($"Filename={_path}");
            optionsBuilder.UseSqlite($"Data Source={_path}");
            //optionsBuilder.LogTo(x => Console.WriteLine(x));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<matrix>()
                .HasMany<word>(m => m.words)
                .WithOne(g => g.matrix)
                .HasForeignKey(s => s.matrix_id);
        }

        public DbSet<matrix> matrices { get; set; }
        public DbSet<word> words { get; set; }
    }
}
