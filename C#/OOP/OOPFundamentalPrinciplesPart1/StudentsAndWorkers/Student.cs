using System;
using System.Linq;

namespace StudentsAndWorkers
{
    class Student : Human
    {
        private double grade;

        public Student(string firstName, string lastName, double grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public double Grade
        {
            get { return this.grade; }
            private set { this.grade = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, {2}", this.FirstName, this.LastName, this.Grade);
        }
    }
}
