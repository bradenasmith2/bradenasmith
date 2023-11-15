using bradenasmith.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
            try
            {
                var repos = await _gitHubApiService.GetAllReposAsync();
                return View(repos);
            }
            catch(Exception ex)
            {
                Log.Fatal($"Failed to grab repos, error: {ex.Message}");
                return BadRequest();
            }
        }

        [Route("/Projects/{Username}/{ProjectName}")]
        public async Task<IActionResult> ProjectShow(string ProjectName, string Username)
        {
            if(ProjectName !=null && Username != null)
            {
                try
                {
                    var repo = await _gitHubApiService.GetProjectAsync(ProjectName, Username);

                    return View(repo);
                }
                catch(Exception ex)
                {
                    Log.Fatal($"Failed to pull repo, error: {ex.Message}");
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
