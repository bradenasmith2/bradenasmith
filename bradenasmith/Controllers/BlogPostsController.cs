using bradenasmith.DataAccess;
using bradenasmith.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace bradenasmith
{
    public class BlogPostsController : Controller
    {
        private readonly bradenasmithContext _context;
        //private readonly IBlogPostService _blogPostService;

        public BlogPostsController(bradenasmithContext context)
        {
            _context = context;
        }

        [Route("/Blogs")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Blogs/{topic}")]
        public IActionResult Show(string topic)
        {
            var blog = _context.BlogPosts.Where(e => e.Topic == topic).Single();
            return View(blog);
        }

        //[Route("/Blogs/New")]
        //public IActionResult New()
        //{
        //    return View();
        //}
    }
}
