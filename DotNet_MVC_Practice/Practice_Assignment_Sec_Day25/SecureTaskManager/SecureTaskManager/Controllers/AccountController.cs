using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManager.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
