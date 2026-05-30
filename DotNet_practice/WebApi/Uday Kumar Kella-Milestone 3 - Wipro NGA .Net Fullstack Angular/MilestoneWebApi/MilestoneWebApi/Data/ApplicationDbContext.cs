using Microsoft.EntityFrameworkCore;
using MilestoneWebApi.Models;

namespace MilestoneWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Note> Notes => Set<Note>();
    }
}