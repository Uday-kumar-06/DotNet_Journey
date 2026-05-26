using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = new List<object>
            {
                new { Id = 1, Product = "Product A", Quantity = 2 },
                new { Id = 2, Product = "Product B", Quantity = 1 }
            };
            return Ok(orders);
        }
    }
}
