using Microsoft.AspNetCore.Mvc;
using MvcModelBindingDemo.Models;

namespace MvcModelBindingDemo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            return View("Result", user);
        }
    }
}
