using Microsoft.AspNetCore.Mvc;

namespace ECommerceRoutingApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}