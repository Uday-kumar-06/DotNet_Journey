using Microsoft.AspNetCore.Mvc;
using OnlineBankingMVC.Filters;

namespace OnlineBankingMVC.Controllers
{
    [CustomAuthenticationFilter]
    [RoleAuthorizationFilter("Admin")]
    public class AdminController : Controller
    {
        public IActionResult AllAccounts()
        {
            return View();
        }
    }
}