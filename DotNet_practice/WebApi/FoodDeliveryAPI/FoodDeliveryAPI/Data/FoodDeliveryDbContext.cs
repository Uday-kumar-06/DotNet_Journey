using FoodDeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.Data
{
    public class FoodDeliveryDbContext:DbContext
    {
        public FoodDeliveryDbContext(DbContextOptions<FoodDeliveryDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Restaurant> Restaurants { get; set; }
        public DbSet<Models.MenuItem> MenuItems { get; set; }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.OrderItem> OrderItems { get; set; }
        public DbSet<Models.DeliveryTracking> DeliveryTrackings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");
            // One-to-One Relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.DeliveryTracking)
                .WithOne(d => d.Order)
                .HasForeignKey<DeliveryTracking>(d => d.OrderId);
        }

    }
}
