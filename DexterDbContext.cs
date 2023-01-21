using Dexter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Dexter
{
    public class DexterDbContext : DbContext
    {
        public DbSet<Pokemon> Blogs { get; set; }

        public string SqliteDbPath { get; }

        public DexterDbContext()
        {
            var folder = Environment.SpecialFolder.Desktop;
            SqliteDbPath = System.IO.Path.Join(Environment.GetFolderPath(folder), "dexter.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Pokemon> seedData = File.ReadAllLines("seed_input.csv")
                                           .Skip(1)
                                           .Select(v => Pokemon.FromCsv(v))
                                           .ToList();
            modelBuilder.Entity<Pokemon>().HasData(seedData.ToArray());
        }
        
        // Create Sqlite DB on desktop
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={SqliteDbPath}");
    }
}
