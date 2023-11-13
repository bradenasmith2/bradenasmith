using bradenasmith.Interfaces;
using bradenasmith.Models;
using Markdig;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace bradenasmith.Services
{
    public class GitHubApiService : IGitHubApiService
    {
        private readonly HttpClient Client;
        private readonly IConfiguration _configuration;

        public GitHubApiService(IConfiguration configuration)
        {
            _configuration = configuration;
            Client = new HttpClient() { BaseAddress = new Uri("https://api.github.com") };
            Client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Bearer", _configuration["GitHubApiToken"]));
        }

        public async Task<List<Project>> GetAllReposAsync()
        {
            string url = "/users/bradenasmith2/repos";
            var result = new List<Project>();
            var response = await Client.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<List<Project>>(stringResponse, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }

        public async Task<Project> GetProjectAsync(string projectName, string username)
        {
            string url = $"/repos/{username}/{projectName}";
            var result = new Project();
            var response = await Client.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<Project>(stringResponse, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase) ;
            }
            result.Content = await GetRepoReadmeAsync(projectName, username);
            return result;
        }

        public async Task<string> GetRepoReadmeAsync(string projectName, string username)
        {
            string url = $"/repos/{username}/{projectName}/readme";
            var response = await Client.GetAsync(url);
            var result = new Readme();
            string htmlContent = "fail";

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<Readme>(jsonResponse, new JsonSerializerOptions() { PropertyNamingPolicy= JsonNamingPolicy.CamelCase });

                byte[] data = Convert.FromBase64String(result.Content);
                string markdownContent = Encoding.UTF8.GetString(data);

                htmlContent = Markdig.Markdown.ToHtml(markdownContent);
            }
            return htmlContent;
        }
    }
}
