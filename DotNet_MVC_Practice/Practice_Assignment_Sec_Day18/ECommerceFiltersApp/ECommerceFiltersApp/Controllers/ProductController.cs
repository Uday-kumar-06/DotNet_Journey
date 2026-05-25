using Microsoft.AspNetCore.Mvc;
using ECommerceFiltersApp.Filters;
using ECommerceFiltersApp.Models;

namespace ECommerceFiltersApp.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 50000
                },
                new Product
                {
                    Id = 2,
                    Name = "Mobile",
                    Price = 20000
                }
            };

            return View(products);
        }

        public IActionResult ErrorDemo()
        {
            throw new Exception("Test Exception");
        }
    }
}