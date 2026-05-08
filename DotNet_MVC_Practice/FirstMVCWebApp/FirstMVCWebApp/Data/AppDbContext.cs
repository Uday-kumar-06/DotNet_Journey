using FirstMVCWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCWebApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        //In place of this we are using Primary Constructor
        //
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{
        //}

        public DbSet<User> Users { get; set; }
    }
}
