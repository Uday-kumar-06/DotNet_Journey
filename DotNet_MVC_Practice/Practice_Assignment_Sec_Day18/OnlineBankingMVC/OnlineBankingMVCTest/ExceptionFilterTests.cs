using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using OnlineBankingMVC.Filters;
using OnlineBankingMVC.Services;
using Xunit;

namespace OnlineBankingMVCTests
{
    public class ExceptionFilterTests
    {
        [Fact]
        public void Handles_Exception_And_Returns_Error_View()
        {
            // Arrange
            var loggingService =
                new Mock<ILoggingService>();

            var httpContext =
                new DefaultHttpContext();

            var actionContext =
                new ActionContext(
                    httpContext,
                    new RouteData(),
                    new ActionDescriptor()
                );

            var context =
                new ExceptionContext(
                    actionContext,
                    new List<IFilterMetadata>()
                );

            context.Exception =
                new Exception("Test Exception");

            var filter =
                new GlobalExceptionFilter(
                    loggingService.Object
                );

            // Act
            filter.OnException(context);

            // Assert
            Assert.True(context.ExceptionHandled);

            var result =
                Assert.IsType<ViewResult>(
                    context.Result
                );

            Assert.Equal("Error", result.ViewName);

            loggingService.Verify(
                x => x.Log(It.IsAny<string>()),
                Times.Once
            );
        }
    }
}