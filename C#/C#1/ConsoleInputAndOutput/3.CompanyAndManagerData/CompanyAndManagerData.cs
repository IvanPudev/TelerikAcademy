using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CompanyAndManagerData
{
    class CompanyAndManagerData
    {
        static void Main(string[] args)
        {
            Console.Write("Enter company name: ");
            string companyName = Console.ReadLine();                  // all of the varaibles except the manager age 
            Console.Write("Enter company address: ");                 // are string, because of the specific lenth of
            string companyAddress = Console.ReadLine();               // the numbers
            Console.Write("Enter company phone number: ");
            string companyPhone = Console.ReadLine();
            Console.Write("Enter company fax number: ");
            string companyFax = Console.ReadLine();
            Console.Write("Enter company web site address: ");
            string companySite = Console.ReadLine();
            Console.WriteLine("Company manager:");
            Console.Write("Enter first name: ");
            string managerFirstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string managerLastName = Console.ReadLine();
            Console.Write("Enter age: ");
            byte managerAge = byte.Parse(Console.ReadLine());
            Console.Write("Enter phone: ");
            string managerPhone = Console.ReadLine();
            Console.WriteLine("The company name is {0}", companyName);
            Console.WriteLine("The company address is {0}", companyAddress);
            Console.WriteLine("The company phone number is {0}", companyPhone);
            Console.WriteLine("The company fax number is {0}", companyFax);
            Console.WriteLine("The company web site address is {0}", companySite);
            Console.WriteLine("The company manager first name is {0}", managerFirstName);
            Console.WriteLine("The company manager last name is {0}", managerLastName);
            Console.WriteLine("The company manager age is {0}", managerAge);
            Console.WriteLine("The company manager phone is {0}", managerPhone);
        }
    }
}
