﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Model
{
    public class Thread
    {
        public Thread()
        {
            this.Categories = new HashSet<Category>();
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual User User{ get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
