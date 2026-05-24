using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingMVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult RoleBasedDashboard(string role)
        {
            if (role == "admin")
            {
                return RedirectToAction("AdminDashboard");
            }

            return RedirectToAction("UserDashboard");
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult UserDashboard()
        {
            return View();
        }

        public IActionResult Index(Guid id)
        {
            ViewBag.Guid = id;

            return View();
        }
    }
}
