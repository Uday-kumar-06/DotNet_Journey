using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
