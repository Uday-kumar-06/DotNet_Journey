using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;

namespace ProductManagement.data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
        }
    }
}
