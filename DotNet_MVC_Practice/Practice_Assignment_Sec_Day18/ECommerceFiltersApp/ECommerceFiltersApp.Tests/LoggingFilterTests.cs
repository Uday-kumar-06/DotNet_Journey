using Xunit;
using Moq;
using ECommerceFiltersApp.Filters;
using ECommerceFiltersApp.Services;

namespace ECommerceFiltersApp.Tests
{
    public class LoggingFilterTests
    {
        [Fact]
        public void Constructor_Should_Create_Instance()
        {
            var loggerMock =
                new Mock<ILoggingService>();

            var filter =
                new LoggingFilter(loggerMock.Object);

            Assert.NotNull(filter);
        }
    }
}