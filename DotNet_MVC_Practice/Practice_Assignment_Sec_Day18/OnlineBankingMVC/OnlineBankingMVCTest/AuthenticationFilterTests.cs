using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using OnlineBankingMVC.Filters;
using OnlineBankingMVCTest;
using Xunit;

namespace OnlineBankingMVCTests
{
    public class AuthenticationFilterTests
    {
        [Fact]
        public void Redirects_To_Login_When_User_Not_Logged_In()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();

            httpContext.Session = new TestSession();

            var actionContext = new ActionContext(
                httpContext,
                new RouteData(),
                new ActionDescriptor()
            );

            var context = new AuthorizationFilterContext(
                actionContext,
                new List<IFilterMetadata>()
            );

            var filter = new CustomAuthenticationFilter();

            // Act
            filter.OnAuthorization(context);

            // Assert
            Assert.NotNull(context.Result);

            var result =
                Assert.IsType<RedirectToActionResult>(
                    context.Result
                );

            Assert.Equal("Login", result.ActionName);
            Assert.Equal("Account", result.ControllerName);
        }
    }
}