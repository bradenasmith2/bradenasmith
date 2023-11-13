using bradenasmith.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace bradenasmith.DataAccess
{
    public class bradenasmithContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public bradenasmithContext(DbContextOptions<bradenasmithContext> options) :base(options) { }
    }
}
