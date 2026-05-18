using Microsoft.EntityFrameworkCore;

namespace Student_Registration_Search_System_AJAX.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
}
