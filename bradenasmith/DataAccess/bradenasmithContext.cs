﻿using Microsoft.EntityFrameworkCore;

namespace bradenasmith.DataAccess
{
    public class bradenasmithContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
