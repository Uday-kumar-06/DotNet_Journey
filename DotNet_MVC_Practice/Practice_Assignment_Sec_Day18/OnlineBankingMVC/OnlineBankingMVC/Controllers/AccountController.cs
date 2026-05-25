using Microsoft.AspNetCore.Mvc;
using OnlineBankingMVC.Services;

namespace OnlineBankingMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService service)
        {
            userService = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (userService.ValidateUser(username, password))
            {
                HttpContext.Session.SetString("User", username);

                var role =
                    userService.GetUserRole(username);

                HttpContext.Session.SetString("Role", role);

                return RedirectToAction(
                    "Dashboard",
                    "Banking"
                );
            }

            ViewBag.Message = "Invalid Credentials";

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}