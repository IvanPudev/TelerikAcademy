using System;
using System.Linq;

namespace Bank
{
    public abstract class Customer
    {
        protected string firstName;
        protected string lastName;

        public string FirstName
        {
            get { return this.firstName; }
            protected set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            protected set { this.lastName = value; }
        }
    }
}
