using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Filters;

namespace OnlineBookStore.Controllers
{
    public class OrdersController : Controller
    {
        [SessionFilter]
        public IActionResult Summary()
        {
            return View();
        }

        [SessionFilter]
        public IActionResult Confirmation()
        {
            return View();
        }
    }
}