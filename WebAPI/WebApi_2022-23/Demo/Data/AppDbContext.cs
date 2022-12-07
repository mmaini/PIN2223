using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Belvedere",
                    Details = "Odlična villa",
                    ImageUrl = "",
                    Occupancy = 3,
                    Rate = 200,
                    Sqft = 200,
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Lungomare",
                    Details = "Obiteljska villa",
                    ImageUrl = "",
                    Occupancy = 5,
                    Rate = 300,
                    Sqft = 300,
                    CreatedDate = DateTime.Now
                }
                );
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

    }
}
