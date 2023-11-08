using bradenasmith.DataAccess;
using bradenasmith.Interfaces;
using bradenasmith.Models;
using System.Net.Http.Headers;

namespace bradenasmith
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
        public string SecOneTitle { get; set; }
        public string SecOneContent { get; set; }
        public string SecTwoTitle { get; set; }
        public string SecTwoContent { get; set; }
        public string? SecThreeTitle { get; set; }
        public string? SecThreeContent { get; set; }
        public string? SecFourTitle { get; set; }
        public string? SecFourContent { get; set; }
        public string? SecFiveTitle { get; set; }
        public string? SecFiveContent { get; set; }

        private readonly bradenasmithContext _context;

        public BlogPost(bradenasmithContext context)
        {
            _context = context;
        }

        public BlogPost GetBlogPost(string topic)
        {
            var post = _context.BlogPosts.Where(e => e.Topic == topic).Single();
            return post;
        }
    }
}
