using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManager.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
