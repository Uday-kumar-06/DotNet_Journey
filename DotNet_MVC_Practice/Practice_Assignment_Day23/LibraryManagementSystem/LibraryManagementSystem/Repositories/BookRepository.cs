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
    public async Task<IEnumerable<Book>> SearchBooks(string title)
    {
        return await _context.Books
            .Where(b => b.Title.Contains(title))
            .ToListAsync();
    }
    public async Task<IEnumerable<Book>> GetBooksSorted()
    {
        return await _context.Books
            .OrderBy(b => b.Title)
            .ToListAsync();
    }
    public async Task<IEnumerable<Book>>
GetBooksPaged(int page, int pageSize)
    {
        return await _context.Books
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<object>>
GetBooksGroupedByGenre()
    {
        return await _context.Books
            .GroupBy(b => b.GenreId)
            .Select(g => new
            {
                Genre = g.Key,
                Count = g.Count()
            })
            .ToListAsync<object>();
    }
}