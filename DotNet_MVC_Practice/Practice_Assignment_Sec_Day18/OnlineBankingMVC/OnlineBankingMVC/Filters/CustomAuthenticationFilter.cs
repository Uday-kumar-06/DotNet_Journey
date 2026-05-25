using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineBankingMVC.Filters
{
    public class CustomAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(user))
            {
                context.Result = new RedirectToActionResult(
                    "Login",
                    "Account",
                    null
                );
            }
        }
    }
}