using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Repository;

namespace OnlineBookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var books = _repository.GetAll();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _repository.GetById(id);
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ManageBooks()
        {
            return View();
        }

    }
}