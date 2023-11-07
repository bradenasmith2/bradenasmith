using bradenasmith.Models;
using System.Net.Http.Headers;

namespace bradenasmith
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();

        private readonly HttpClient Client;
        private readonly IConfiguration _configuration;

        public BlogPost(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<BlogPost> GetBlogPostAsync(string title)
        {
        
        }
    }
}
