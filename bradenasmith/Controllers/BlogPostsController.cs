using Microsoft.AspNetCore.Mvc;

namespace bradenasmith.Controllers
{
    public class BlogPostsController : Controller
    {
        [Route("/Blogs")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
