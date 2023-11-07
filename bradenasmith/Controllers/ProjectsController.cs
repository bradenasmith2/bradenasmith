using bradenasmith.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bradenasmith.Controllers
{
    public class ProjectsController : Controller // [ GITHUB API CONTROLLER ]
    {
        private readonly IGitHubApiService _gitHubApiService;

        public ProjectsController(IGitHubApiService gitHubApiService)
        {
            _gitHubApiService = gitHubApiService;
        }

        [Route("/Projects")]
        public async Task<IActionResult> Index()
        {
            var repos = await _gitHubApiService.GetAllReposAsync();
            return View(repos);
        }

        [Route("/Projects/{Username}/{ProjectName}")]
        public async Task<IActionResult> ProjectShow(string ProjectName, string Username)
        {
            var repo = await _gitHubApiService.GetProjectAsync(ProjectName, Username);
            return View(repo);
        }
    }
}
