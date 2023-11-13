using System.Text.Json.Serialization;

namespace bradenasmith.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Content { get; set; }
        public List<string>? Collaborators { get; set; }
        public int? NumCommits { get; set; }
        public string? DateCreated { get; set; }
    }
}
