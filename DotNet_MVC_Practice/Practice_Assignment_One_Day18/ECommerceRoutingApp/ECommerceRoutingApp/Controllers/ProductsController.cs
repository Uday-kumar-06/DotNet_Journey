using ECommerceRoutingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceRoutingApp.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Category = "electronics",
                Price = 50000
            },

            new Product
            {
                Id = 2,
                Name = "Shirt",
                Category = "fashion",
                Price = 1500
            },

            new Product
            {
                Id = 3,
                Name = "Java Book",
                Category = "books",
                Price = 900
            }
        };

   
        public IActionResult Details(string category, int id)
        {
            var product = products.FirstOrDefault(p =>
                p.Category.ToLower() == category.ToLower()
                && p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

       
        public IActionResult Filter(string category, string priceRange)
        {
            string[] range = priceRange.Split('-');

            decimal min = Convert.ToDecimal(range[0]);
            decimal max = Convert.ToDecimal(range[1]);

            var filteredProducts = products.Where(p =>
                p.Category.ToLower() == category.ToLower()
                && p.Price >= min
                && p.Price <= max).ToList();

            ViewBag.Category = category;
            ViewBag.PriceRange = priceRange;

            return View(filteredProducts);
        }
    }
}
