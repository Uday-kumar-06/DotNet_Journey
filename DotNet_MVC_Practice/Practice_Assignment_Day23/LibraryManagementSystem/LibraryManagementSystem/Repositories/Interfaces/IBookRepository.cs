using LibraryManagementSystem.Models;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksWithDetails();

    Task<IEnumerable<Book>> SearchBooks(string title);

    Task<IEnumerable<Book>> GetBooksSorted();

    Task<IEnumerable<Book>> GetBooksPaged(int page,
                                          int pageSize);
}