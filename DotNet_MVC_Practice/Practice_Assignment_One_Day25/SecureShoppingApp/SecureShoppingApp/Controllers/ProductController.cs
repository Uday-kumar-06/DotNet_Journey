using Microsoft.AspNetCore.Mvc;

namespace SecureShoppingApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
