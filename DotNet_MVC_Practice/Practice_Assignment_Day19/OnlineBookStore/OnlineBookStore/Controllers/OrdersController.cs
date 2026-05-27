using Microsoft.AspNetCore.Mvc;

namespace OnlineBookStore.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Summary()
        {
            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}