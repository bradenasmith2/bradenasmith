using bradenasmith.DataAccess;
using bradenasmith.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Serilog;

namespace bradenasmith.Controllers
{
    public class CommentsController : Controller
    {
        private readonly bradenasmithContext _context;
        
        public CommentsController(bradenasmithContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/Blogs/{topic}/Comment/New")]
        public IActionResult Index(string topic, Comment comment, int BlogPostId)//BlogPostId comes from a HIDDEN input.
        {
            if(topic != null && comment != null && BlogPostId != null) 
            {
                if (Request.Cookies["AnonUser"] == null)
                {
                    string anonId = Guid.NewGuid().ToString();
                    var anonUser = new User();

                    anonUser.Id = anonId;
                    Response.Cookies.Append("AnonUser", anonId);
                    comment.AnonId = anonId;
                    comment.BlogPost = _context.BlogPosts.Find(BlogPostId);
                    comment.CreatedAt = DateTime.Now.ToUniversalTime();
                    anonUser.Comments.Add(comment);
                }
                else
                {
                    var anonUser = new User();

                    anonUser.Id = Request.Cookies["AnonUser"];

                    comment.BlogPost = _context.BlogPosts.Find(BlogPostId);
                    comment.CreatedAt = DateTime.Now.ToUniversalTime();
                    comment.AnonId = anonUser.Id;
                    anonUser.Comments.Add(comment);
                }
                _context.Comments.Add(comment);
                _context.SaveChanges();

                return Redirect($"/Blogs/{topic}");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/Blogs/{topic}/Comment/{commentId}/Edit")]
        public IActionResult Edit(string topic, int commentId, Comment updatedComment)
        {
            if(topic != null && commentId != null && updatedComment != null)
            {
                if (updatedComment.AnonId == Request.Cookies["AnonUserId"])
                {
                    try
                    {
                        var blog = _context.BlogPosts.Include(e => e.Comments).Where(e => e.Topic.ToLower() == topic.ToLower()).FirstOrDefault();
                        var comment = blog.Comments.FirstOrDefault(c => c.Id == commentId);

                        comment.Content = updatedComment.Content;
                        _context.SaveChanges();

                        return Redirect($"/Blogs/{topic}");
                    }
                    catch(Exception ex) 
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
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/Blogs/{topic}/Comment/{commentId}/Delete")]
        public IActionResult Delete(string topic, int commentId)
        {
            if(topic != null && commentId != null)
            {
                try
                {

                }
                catch(Exception ex)
                {
                    Log.Warning($"Failed to fetch Db data, error: {ex.Message}");
                }
                var blog = _context.BlogPosts.Include(e => e.Comments).Where(e => e.Topic.ToLower() == topic.ToLower()).FirstOrDefault();
                var comment = blog.Comments.FirstOrDefault(e => e.Id == commentId);
                _context.Comments.Remove(comment);
                _context.SaveChanges();

                return Redirect($"/Blogs/{topic}");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
