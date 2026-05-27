using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineBookStore.Filters
{
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(
            ActionExecutingContext context)
        {
            var sessionValue =
                context.HttpContext.Session.GetString("Cart");

            if (string.IsNullOrEmpty(sessionValue))
            {
                context.Result = new RedirectToActionResult(
                    "Index",
                    "Books",
                    null);
            }

            base.OnActionExecuting(context);
        }
    }
}