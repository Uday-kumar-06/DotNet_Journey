using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Customer")]
public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}