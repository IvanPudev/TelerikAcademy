using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Model
{
    public class Student
    {
        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
        public short Grade { get; set; }

        public virtual School School { get; set; }

        public ICollection<Mark> Marks { get; set; }
    }
}
