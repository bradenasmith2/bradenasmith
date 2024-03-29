﻿using Microsoft.AspNetCore.Http;

namespace bradenasmith.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public BlogPost BlogPost { get; set; }
        public string AnonId { get; set; }
    }
}
