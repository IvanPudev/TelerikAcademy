using System;
using System.Data.Entity;
using System.Linq;
using BloggingSystem.Model;

namespace BloggingSystem.Data
{
    public class BloggingSystmContext : DbContext
    {
        public BloggingSystmContext()
            : base("BloggingSystemDb")
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Coments { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
