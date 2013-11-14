using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using BloggingSystem.Model;

namespace BloggingSystem.Model
{
    public class Post
    {
        public Post()
        {
            this.Tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual User ByUser { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
