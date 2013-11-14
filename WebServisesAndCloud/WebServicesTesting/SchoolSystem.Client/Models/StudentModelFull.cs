using SchoolSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Client.Models
{
    public class StudentModelFull : StudentModel
    {
        public School School { get; set; }

        public ICollection<Mark> Marks { get; set; }
    }
}