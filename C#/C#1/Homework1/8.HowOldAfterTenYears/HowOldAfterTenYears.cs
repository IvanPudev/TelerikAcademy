using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.HowOldAfterTenYears
{
    class HowOldAfterTenYears
    {
        static void Main(string[] args)
        {           
            Console.Write("Enter your present age:");
            Byte presentAge = Byte.Parse(Console.ReadLine());       
            Console.WriteLine("After a decade you will be {0} years old.", (presentAge + 10));
        }
    }
}
