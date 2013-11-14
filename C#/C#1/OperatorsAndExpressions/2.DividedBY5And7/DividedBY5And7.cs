using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.DividedBY5And7
{
    class DividedBY5And7
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer number: ");
            int number = int.Parse(Console.ReadLine());
            if (number % 35 == 0)
            {
                Console.WriteLine("The number {0} can be divided by 5 and 7 at the same time.", number);
            }
            else
            {
                Console.WriteLine("The number {0} cannot be divided by 5 and 7 at the same time.", number);
            }
        }
    }
}
