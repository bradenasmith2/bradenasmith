using bradenasmith.DataAccess;
using bradenasmith.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace bradenasmith.Controllers
{
    public class CommentsController : Controller
    {
        private readonly bradenasmithContext _context;
        
        public CommentsController(bradenasmithContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/Blogs/{topic}/Comment/New")]
        public IActionResult Index(string topic, Comment comment, int BlogPostId)
        {
            comment.BlogPost = _context.BlogPosts.Find(BlogPostId);
            comment.CreatedAt = DateTime.Now.ToUniversalTime();

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return Redirect($"/blogs/{topic}");
        }
    }
}
