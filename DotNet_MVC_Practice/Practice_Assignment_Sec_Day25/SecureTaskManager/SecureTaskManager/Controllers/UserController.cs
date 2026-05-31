using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManager.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class UserController : Controller
    {
        public IActionResult TaskList()
        {
            return View();
        }

        [Authorize(Policy = "CanEditTask")]
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}