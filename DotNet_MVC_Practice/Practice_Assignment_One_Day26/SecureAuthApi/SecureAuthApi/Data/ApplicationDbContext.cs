using Microsoft.EntityFrameworkCore;
using SecureAuthApi.Models;

namespace SecureAuthApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}