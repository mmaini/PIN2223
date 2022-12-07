
using LoginDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LocalUser> LocalUsers { get; set; }

    }
}
