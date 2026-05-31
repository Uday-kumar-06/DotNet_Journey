using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManager.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
