using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1DbContext : DbContext
    {
        public WebApplication1DbContext(DbContextOptions<WebApplication1DbContext> options)
           : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<User>().ToTable("User")
                .HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Admin>().ToTable("Admin");
        }
    }
}
