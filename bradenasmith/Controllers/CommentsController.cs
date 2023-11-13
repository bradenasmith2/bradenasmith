using bradenasmith.DataAccess;
using bradenasmith.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index(string topic, Comment comment, int BlogPostId)//BlogPostId comes from a HIDDEN input.
        {
            string uniqueIdentifier = Guid.NewGuid().ToString();

            Response.Cookies.Append("AnonUser", uniqueIdentifier);

            comment.AnonId = uniqueIdentifier;
            comment.BlogPost = _context.BlogPosts.Find(BlogPostId);
            comment.CreatedAt = DateTime.Now.ToUniversalTime();

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return Redirect($"/blogs/{topic}");
        }

        [HttpPost]
        [Route("/Blogs/{topic}/Comment/{commentId}/Edit")]
        public IActionResult Edit(string topic, int commentId, Comment updatedComment)
        {
            if(updatedComment.AnonId == Request.Cookies["AnonUserId"])
            {
                var blog = _context.BlogPosts.Include(e => e.Comments).Where(e => e.Topic.ToLower() == topic.ToLower()).FirstOrDefault();
                var comment = blog.Comments.FirstOrDefault(c => c.Id == commentId);

                comment.Content = updatedComment.Content;
                _context.SaveChanges();

                return Redirect($"/Blogs/{topic}");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/Blogs/{topic}/Comment/{commentId}/Delete")]
        public IActionResult Delete(string topic, int commentId)
        {
            var blog = _context.BlogPosts.Include(e => e.Comments).Where(e => e.Topic.ToLower() == topic.ToLower()).FirstOrDefault();
            var comment = blog.Comments.FirstOrDefault(e => e.Id == commentId);
            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return Redirect($"/Blogs/{topic}");
        }
    }
}
