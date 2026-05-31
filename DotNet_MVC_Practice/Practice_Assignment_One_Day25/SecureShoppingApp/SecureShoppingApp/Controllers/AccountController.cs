using Microsoft.AspNetCore.Mvc;

namespace SecureShoppingApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
