using bradenasmith.Models;

namespace bradenasmith
{
    public interface IBlogPostService
    {
        BlogPost GetBlogPost(string title);
    }
}
