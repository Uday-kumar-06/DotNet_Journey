using AjaxDemoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AjaxDemoApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetMessage(string name)
        {
            string message = $"Hello, {name}! This message is from the server.";
            return Json(new { Message = message });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
