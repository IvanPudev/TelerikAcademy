using System;
using System.Linq;

namespace SchoolSystem.Client.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public short Age { get; set; }

        public short Grade { get; set; }
    }
}
