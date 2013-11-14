using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Model
{
    public class Category
    {
        public Category()
        {
            this.Threads = new HashSet<Thread>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }
    }
}
