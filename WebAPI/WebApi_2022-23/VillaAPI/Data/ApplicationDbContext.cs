
using Microsoft.EntityFrameworkCore;
using System;
using VillaAPI.Models;

namespace VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Belvedere",
                    Details = "Detalji",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 200,
                    Sqft = 550,
                    CreatedDate = DateTime.Now
                },
              new Villa
              {
                  Id = 2,
                  Name = "Premium Pool Villa",
                  Details = "Detalji",
                  ImageUrl = "",
                  Occupancy = 4,
                  Rate = 300,
                  Sqft = 550,
                  CreatedDate = DateTime.Now
              });
        }
    }
}
