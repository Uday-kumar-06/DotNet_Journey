using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;

namespace LibraryManagementSystem.Repositories
{
    public class AuthorRepository :
        Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context)
            : base(context)
        {
        }
    }
}