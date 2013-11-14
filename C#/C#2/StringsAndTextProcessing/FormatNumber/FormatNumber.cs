using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatNumber
{
    class FormatNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("{0,15}", number);   // Decimal
            Console.WriteLine("{0,15:X}", number); // Hexadecimal
            Console.WriteLine("{0,15:P}", number); // Percentage
            Console.WriteLine("{0,15:E}", number); // Exponential notation
        }
    }
}
