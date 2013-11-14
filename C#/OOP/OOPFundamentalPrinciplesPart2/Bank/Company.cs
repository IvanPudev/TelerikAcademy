using System;
using System.Linq;

namespace Bank
{
    public class Company : Customer
    {
        public Company(string companyName)
        {
            this.FirstName = companyName;
        }
    }
}
