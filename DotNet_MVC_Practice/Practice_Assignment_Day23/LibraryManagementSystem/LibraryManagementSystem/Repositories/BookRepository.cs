using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

public class BookRepository :
Repository<Book>, IBookRepository
{
    private readonly LibraryDbContext _context;

    public BookRepository(LibraryDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>>
        GetBooksWithDetails()
    {
        return await _context.Books
            .Include(b => b.Author)
            .Include(b => b.Genre)
            .ToListAsync();
    }
}