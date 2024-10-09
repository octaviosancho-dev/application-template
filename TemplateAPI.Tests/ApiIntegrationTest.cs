using Microsoft.AspNetCore.Mvc.Testing;

namespace TemplateAPI.Tests
{
    public class ApiIntegrationTest
    {
        private readonly HttpClient _client;
        public ApiIntegrationTest()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _client = webAppFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task GetValues_ReturnsSuccess()
        {

            var response = await _client.GetAsync("/api/values");

            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}

