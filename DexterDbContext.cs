using Dexter.Models;
using Microsoft.EntityFrameworkCore;

namespace Dexter
{
    public class DexterDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }

        public string? SqliteDbPath { get; }

        public DexterDbContext()
        {
            var folder = Environment.SpecialFolder.Desktop;
            SqliteDbPath = System.IO.Path.Join(Environment.GetFolderPath(folder), "dexter.db");
        }
        public DexterDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* This code was used to generate the intial migration which is now stored in the migration file itself
             * so saving it off here commented in case needed in the future
             * 
            
            List<Pokemon> seedData = File.ReadAllLines("seed_input.csv")
                                            .Skip(1)
                                            .Select(v => Pokemon.FromCsv(v))
                                            .ToList();
            modelBuilder.Entity<Pokemon>().HasData(seedData.ToArray());
            */
        }
        
        // Create Sqlite DB on desktop
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite($"Data Source={SqliteDbPath}");
            }
        }
    }
}
