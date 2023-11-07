using bradenasmith.Interfaces;
using bradenasmith.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace bradenasmith.Services
{
    public class GitHubApiService : IGitHubApiService
    {
        private readonly HttpClient Client;

        public GitHubApiService()
        {
            Client = new HttpClient() { BaseAddress = new Uri("https://api.github.com") };
            Client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Bearer", "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"));
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
    }
}
