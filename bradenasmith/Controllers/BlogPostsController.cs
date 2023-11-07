using Microsoft.AspNetCore.Mvc;

namespace bradenasmith.Controllers
{
    public class BlogPostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
