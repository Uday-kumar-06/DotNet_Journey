using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingMVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Details(string category, int id)
        {
            ViewBag.Category = category;
            ViewBag.ProductId = id;

            return View();
        }
    }
}
