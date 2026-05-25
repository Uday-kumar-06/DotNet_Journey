using Microsoft.AspNetCore.Mvc;

namespace ECommerceFiltersApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return Content("Please Login First");
        }
    }
}