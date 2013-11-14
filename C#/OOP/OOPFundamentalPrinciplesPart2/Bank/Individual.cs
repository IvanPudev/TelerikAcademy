using System;
using System.Linq;

namespace Bank
{
    public class Individual : Customer
    {
        public Individual(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}