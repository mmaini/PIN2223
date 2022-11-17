using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;

namespace WebAPIDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Villa> Villas { get; set; }

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
                    Amenity = "",
                    CreatedDate= DateTime.Now
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
                    Amenity = "",
                    CreatedDate = DateTime.Now
                }
                ); 
        }
    }
}
