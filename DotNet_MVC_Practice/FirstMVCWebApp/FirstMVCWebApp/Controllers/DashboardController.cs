using FirstMVCWebApp.Data;
using FirstMVCWebApp.Dto;
using FirstMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCWebApp.Controllers
{
    public class DashboardController(AppDbContext dbContext) : Controller
    {
        public IActionResult Index()
        {
            var list = dbContext.Products
                .Select(x => new ProductResponseDto(
                    x.Id,
                    x.ProductName,
                    x.Description,
                    x.Price,
                    x.Color
                ))
                .ToList();
            return View(list);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public async Task<IActionResult> CreateProduct(ProductRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Please fill in all required fields.";
                return View("AddProduct");
            }
            var product = new Product
            {
                ProductName = request.ProductName,
                Description = request.Description,
                Price = request.Price,
                Color = request.Color
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
