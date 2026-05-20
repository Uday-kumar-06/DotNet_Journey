using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureECommercePortal.Controllers
{
    public class SellerController : Controller
    {
        [Authorize(Roles = "Seller")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
