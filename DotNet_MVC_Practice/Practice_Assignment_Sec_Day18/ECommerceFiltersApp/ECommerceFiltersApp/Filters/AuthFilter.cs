using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ECommerceFiltersApp.Services;

namespace ECommerceFiltersApp.Filters
{
    public class AuthFilter : IAuthorizationFilter
    {
        private readonly IAuthService _authService;

        public AuthFilter(IAuthService authService)
        {
            _authService = authService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_authService.IsAuthenticated())
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