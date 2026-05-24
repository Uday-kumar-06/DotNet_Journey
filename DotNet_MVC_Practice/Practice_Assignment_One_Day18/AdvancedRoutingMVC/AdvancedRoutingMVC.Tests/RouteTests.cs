using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AdvancedRoutingMVC.Tests
{
    public class RouteTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient client;

        public RouteTests(WebApplicationFactory<Program> factory)
        {
            client = factory.CreateClient();
        }

        [Fact]
        public async Task ProductRoute_ReturnsSuccess()
        {
            var response = await client.GetAsync("/Products/Electronics/101");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UserOrdersRoute_ReturnsSuccess()
        {
            var response = await client.GetAsync("/Users/john/Orders");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ValidGuidRoute_ReturnsSuccess()
        {
            var response = await client.GetAsync(
                "/Dashboard/123e4567-e89b-12d3-a456-426614174000");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task InvalidGuidRoute_ReturnsNotFound()
        {
            var response = await client.GetAsync("/Dashboard/abc123");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}