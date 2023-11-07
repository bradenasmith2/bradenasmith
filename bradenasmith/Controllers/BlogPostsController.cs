using bradenasmith.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace bradenasmith.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly IGitHubApiService _gitHubApiService;

        public BlogPostsController(IGitHubApiService gitHubApiService)
        {
            _gitHubApiService = gitHubApiService;
        }

        [Route("/Blogs")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Blogs/{Title}")]
        public IActionResult Show(string Title)
        {
            return View();
        }
    }
}
