using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;

namespace LibraryManagementSystem.Repositories
{
    public class GenreRepository :
        Repository<Genre>, IGenreRepository
    {
        public GenreRepository(LibraryDbContext context)
            : base(context)
        {
        }
    }
}