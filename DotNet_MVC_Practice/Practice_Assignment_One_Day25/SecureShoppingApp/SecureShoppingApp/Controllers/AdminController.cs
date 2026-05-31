using Microsoft.AspNetCore.Mvc;

namespace SecureShoppingApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
