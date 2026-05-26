using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new List<string>
            {
                "Laptop",
                "Mobile",
                "Keyboard"
            };

            return Ok(products);
        }
    }
}
