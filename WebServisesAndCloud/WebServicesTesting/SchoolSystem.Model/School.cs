using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Model
{
    public class School
    {
        public School()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
