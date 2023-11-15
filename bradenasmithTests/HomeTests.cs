using Microsoft.AspNetCore.Mvc.Testing;

namespace bradenasmithTests
{
    public class HomeTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public HomeTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Home_ResumeReturnsViewWithResumeContent()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Resume");
            var html = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.Contains("Technical Skills", html);
            Assert.Contains("Projects", html);
            Assert.Contains("Progessional Experience", html);
            Assert.Contains("Education", html);
        }

        [Fact]
        public async void Home_BackgroundReturnsViewWithBackgroundContent()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/");
            var html = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.Contains("Hey there", html);
            Assert.Contains("My toolkit", html);
            Assert.Contains("Beyond the code", html);
        }

        [Fact]
        public async void Home_IndexReturnsViewWithAboutMeContent()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/");
            var html = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.Contains("Braden Smith", html);
            Assert.Contains("Full-Stack Engineer", html);
        }
    }
}