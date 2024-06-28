using Microsoft.EntityFrameworkCore;

namespace PortfoiloAPI.Models
{
    public class PortfoiloDbContext : DbContext
    {
        public PortfoiloDbContext(DbContextOptions<PortfoiloDbContext> options)
          : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
