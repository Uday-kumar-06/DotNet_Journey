using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _repo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IGenreRepository _genreRepo;

        public BooksController(
            IBookRepository repo,
            IAuthorRepository authorRepo,
            IGenreRepository genreRepo)
        {
            _repo = repo;
            _authorRepo = authorRepo;
            _genreRepo = genreRepo;
        }

        // GET: Books
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 5;

            var books = await _repo.GetBooksPaged(page, pageSize);

            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await _repo.GetByIdAsync(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors =
                new SelectList(await _authorRepo.GetAllAsync(),
                               "AuthorId",
                               "Name");

            ViewBag.Genres =
                new SelectList(await _genreRepo.GetAllAsync(),
                               "GenreId",
                               "GenreName");

            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(book);

                return Json(new
                {
                    success = true,
                    message = "Book Added Successfully"
                });
            }

            return BadRequest("Failed to add book");
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _repo.GetByIdAsync(id);

            if (book == null)
                return NotFound();

            ViewBag.Authors =
                new SelectList(await _authorRepo.GetAllAsync(),
                               "AuthorId",
                               "Name",
                               book.AuthorId);

            ViewBag.Genres =
                new SelectList(await _genreRepo.GetAllAsync(),
                               "GenreId",
                               "GenreName",
                               book.GenreId);

            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                await _repo.UpdateAsync(book);

                return Json(new
                {
                    success = true,
                    message = "Book Updated Successfully"
                });
            }

            return BadRequest("Update Failed");
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _repo.GetByIdAsync(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);

            return Json(new
            {
                success = true,
                message = "Book Deleted Successfully"
            });
        }
    }
}