using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using BackendAPI;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;

namespace BackendAPI.Test
{
    public class BasicTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BasicTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Product")]
        [InlineData("/api/Recepie")]
        public async Task HttpGet(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/Product/id?id=0")]
        [InlineData("/api/Recepie/id?id=0")]
        public async Task HttpGet404(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal("NotFound", response.StatusCode.ToString());
        }

        [Theory]
        [InlineData("/auth/login")]
        public async Task HttpAuthLogin(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            string content = "{\"id\": 0,\"name\": \"string\",\"password\": \"string\",\"email\": \"string\"}";
            StringContent c = new StringContent(content, UTF32Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, c);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/auth/login")]
        public async Task HttpAuthLogin404(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            string content = "{\"id\": 0,\"name\": \"string\",\"password\": \"N/A\",\"email\": \"N/A\"}";
            StringContent c = new StringContent(content, UTF32Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, c);

            // Assert
            Assert.Equal("NotFound", response.StatusCode.ToString());
        }
    }
}
