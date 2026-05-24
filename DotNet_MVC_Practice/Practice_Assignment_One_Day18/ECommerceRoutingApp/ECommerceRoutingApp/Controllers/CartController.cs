using Microsoft.AspNetCore.Mvc;

namespace ECommerceRoutingApp.Controllers
{
    public class CartController : Controller
    {
        private bool IsLoggedIn()
        {
            return false;
        }

        public IActionResult Checkout()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}