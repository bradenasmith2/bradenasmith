using bradenasmith.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace bradenasmith
{
    public class BlogPostsController : Controller
    {
        //private readonly IBlogPostService _blogPostService;

        //public BlogPostsController(IBlogPostService blogPostService)
        //{
        //    _blogPostService = blogPostService;
        //}

        [Route("/Blogs")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Blogs/{Title}")]
        public IActionResult Show(string topic)
        {
            return View();
        }

        [Route("/Blogs/New")]
        public IActionResult New()
        {
            return View();
        }
    }
}
