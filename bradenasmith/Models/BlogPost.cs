namespace bradenasmith.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
    }
}
