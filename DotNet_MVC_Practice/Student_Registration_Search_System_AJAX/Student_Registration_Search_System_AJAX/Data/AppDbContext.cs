using Microsoft.EntityFrameworkCore;
using Student_Registration_Search_System_AJAX.Models;

namespace Student_Registration_Search_System_AJAX.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
