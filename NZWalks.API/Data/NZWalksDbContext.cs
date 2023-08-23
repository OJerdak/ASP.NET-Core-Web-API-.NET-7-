using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) 
            :base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("a4fc373a-887a-461f-988d-e8fa0a32d126"),
                    Name = "Easy"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("f3411f29-5cf1-4c85-a627-773052ea3aa5"),
                    Name = "Medium"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("7d79081a-22f5-4bb9-8a18-b9f3e730ae2e"),
                    Name = "Hard"
                }
            };

            //seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("47cdee8f-0641-41eb-ab8a-e4ae65e676f1"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "image.com"
                },
                new Region()
                {
                    Id = Guid.Parse("7b3476cb-bc86-43a7-abf5-a908709b2f3b"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "image.com"
                },
                new Region()
                {
                    Id = Guid.Parse("17cc1a14-3a5b-40c5-aac0-504d54d81493"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "image.com"
                },
                new Region()
                {
                    Id = Guid.Parse("337fbaa5-e350-4afe-bf96-5167fc5f6a3c"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "image.com"
                }
            };

            //seed difficulties to the database
            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
