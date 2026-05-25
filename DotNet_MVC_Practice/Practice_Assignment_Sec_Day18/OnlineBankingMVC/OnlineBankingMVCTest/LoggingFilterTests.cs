using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using OnlineBankingMVC.Filters;
using OnlineBankingMVC.Services;
using Xunit;

namespace OnlineBankingMVCTest
{
    public class LoggingFilterTests
    {
        [Fact]
        public void Logs_User_Action()
        {
            // Arrange
            var loggingService =
                new Mock<ILoggingService>();

            var httpContext =
                new DefaultHttpContext();

            httpContext.Session =
                new TestSession();

            httpContext.Session.SetString(
                "User",
                "admin"
            );

            var actionContext =
                new Microsoft.AspNetCore.Mvc.ActionContext(
                    httpContext,
                    new RouteData(),
                    new ActionDescriptor()
                );

            var context =
                new ActionExecutingContext(
                    actionContext,
                    new List<IFilterMetadata>(),
                    new Dictionary<string, object>(),
                    null
                );

            var filter =
                new ActionLoggingFilter(
                    loggingService.Object
                );

            // Act
            filter.OnActionExecuting(context);

            // Assert
            loggingService.Verify(
                x => x.Log(It.IsAny<string>()),
                Times.Once
            );
        }
    }
}
