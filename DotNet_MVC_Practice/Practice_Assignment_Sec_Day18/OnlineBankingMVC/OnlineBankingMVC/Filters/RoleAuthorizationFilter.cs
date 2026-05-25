using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineBankingMVC.Filters
{
    public class RoleAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string requiredRole;

        public RoleAuthorizationFilter(string role)
        {
            requiredRole = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var role = context.HttpContext.Session.GetString("Role");

            if (role != requiredRole)
            {
                context.Result = new ContentResult
                {
                    Content = "Access Denied"
                };
            }
        }
    }
}