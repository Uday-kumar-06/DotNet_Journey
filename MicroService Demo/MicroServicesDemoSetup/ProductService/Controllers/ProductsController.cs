using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new List<object>
            {
                new { Id = 1, Name = "Product A", Price = 10.0 },
                new { Id = 2, Name = "Product B", Price = 20.0 }
            };
            return Ok(products);
        }
    }
}
