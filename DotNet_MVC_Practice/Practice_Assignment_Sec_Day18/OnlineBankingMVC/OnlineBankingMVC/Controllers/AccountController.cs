using Microsoft.AspNetCore.Mvc;

namespace OnlineBankingMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
