using Microsoft.AspNetCore.Mvc;

namespace BookStoreADO.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
