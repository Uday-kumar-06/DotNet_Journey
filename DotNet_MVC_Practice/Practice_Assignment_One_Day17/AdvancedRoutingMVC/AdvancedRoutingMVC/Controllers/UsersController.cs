using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingMVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Orders(string username)
        {
            ViewBag.Username = username;

            return View();
        }
    }
}
