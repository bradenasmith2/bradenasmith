using bradenasmith.DataAccess;
using bradenasmith.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
            if(topic != null)
            {
                try
                {
                    var blog = _context.BlogPosts.Include(e => e.Comments).Where(e => e.Topic.ToLower() == topic.ToLower()).SingleOrDefault();

                    ViewData["AnonUserId"] = Request.Cookies["AnonUser"];
                    return View(blog);
                }
                catch (Exception ex)
                {
                    Log.Warning($"Failed to fetch Db data, error: {ex.Message}");
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //this form is built out, but cannot be submitted, nor should anon users be allowed to access this. REQUIRES IDENTITY
        //[Route("/Blogs/New")]
        //public IActionResult New()
        //{
        //    return View();
        //}
    }
}
