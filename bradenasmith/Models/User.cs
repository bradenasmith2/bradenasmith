using Microsoft.AspNetCore.Identity;

namespace bradenasmith.Models
{
    public class User : IdentityUser
    {
        public override string Id { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
