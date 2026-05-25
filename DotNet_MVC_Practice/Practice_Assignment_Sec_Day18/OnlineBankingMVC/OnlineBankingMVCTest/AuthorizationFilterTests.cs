using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineBankingMVC.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBankingMVCTest
{
    public class AuthorizationFilterTests
    {
        [Fact]
        public void Denies_Access_When_Role_Is_Not_Admin()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();

            httpContext.Session =
                new TestSession();

            httpContext.Session.SetString("Role", "User");

            var actionContext =
                new ActionContext(
                    httpContext,
                    new Microsoft.AspNetCore.Routing.RouteData(),
                    new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()
                );

            var context =
                new AuthorizationFilterContext(
                    actionContext,
                    new List<IFilterMetadata>()
                );

            var filter =
                new RoleAuthorizationFilter("Admin");

            // Act
            filter.OnAuthorization(context);

            // Assert
            Assert.NotNull(context.Result);

            var result =
                Assert.IsType<ContentResult>(context.Result);

            Assert.Equal("Access Denied", result.Content);
        }
    }
}
