using Microsoft.AspNetCore.Mvc;

namespace bradenasmith.Controllers
{
    public class CommentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
