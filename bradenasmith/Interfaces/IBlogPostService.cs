using bradenasmith.Models;

namespace bradenasmith.Interfaces
{
    public interface IBlogPostService
    {
        Task<BlogPost> GetBlogPost(string title);
    }
}
