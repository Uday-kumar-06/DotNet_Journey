using LibraryManagementSystem.Models;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksWithDetails();
}