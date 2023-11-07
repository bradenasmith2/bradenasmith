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
    }
}
