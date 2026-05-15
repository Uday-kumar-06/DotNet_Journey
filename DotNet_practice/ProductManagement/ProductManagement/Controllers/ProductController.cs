using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using ProductManagement.Repositories;

namespace ProductManagement.Controllers
{
    public class ProductController(IProductRepository repository) : Controlle
    {

        public IActionResult Index()
        {
            var products = repository.GetAllProducts();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Add(product);

                repository.Save();

                return RedirectToAction("Index");
            }

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            repository.Delete(id);

            repository.Save();

            return RedirectToAction("Index");
        }
    }
}
