using Microsoft.AspNetCore.Mvc;
using OnlineBankingMVC.Filters;

namespace OnlineBankingMVC.Controllers
{
    [CustomAuthenticationFilter]
    public class BankingController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Transactions()
        {
            return View();
        }

        public IActionResult Transfer()
        {
            return View();
        }
    }
}