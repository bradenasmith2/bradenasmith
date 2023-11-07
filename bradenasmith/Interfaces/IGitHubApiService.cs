using bradenasmith.Models;
namespace bradenasmith.Interfaces
{
    public interface IGitHubApiService
    {
        Task<List<Project>> GetAllReposAsync();
        Task<Project> GetProjectAsync(string projectName, string username);
    }
}
