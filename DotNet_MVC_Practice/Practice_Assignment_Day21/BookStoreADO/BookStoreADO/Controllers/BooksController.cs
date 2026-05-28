using BookStoreADO.Models;
using BookStoreADO.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreADO.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookRepository _repository;

        public BooksController(BookRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var books = _repository.GetAllBooks();

            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.AddBook(book);

                return RedirectToAction("Index");
            }

            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _repository.GetBookById(id);

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _repository.UpdateBook(book);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _repository.DeleteBook(id);

            return RedirectToAction("Index");
        }
    }
}