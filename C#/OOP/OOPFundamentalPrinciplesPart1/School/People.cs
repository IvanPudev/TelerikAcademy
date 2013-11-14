using System;
using System.Linq;

namespace School
{
    abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set { this.lastName = value; }
        }
    }
}
