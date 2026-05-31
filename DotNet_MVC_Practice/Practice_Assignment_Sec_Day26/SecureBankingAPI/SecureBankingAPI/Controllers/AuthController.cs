using Microsoft.AspNetCore.Mvc;

namespace SecureBankingAPI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
