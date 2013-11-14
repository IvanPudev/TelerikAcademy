using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ExchangingPlacesOfComperativeInt
{
    class ExchangingPlacesOfComperativeInt
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first integer: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int b = int.Parse(Console.ReadLine());
            int c = a;

            if (a > b)
            {
                a = b;
                b = c;
                Console.WriteLine("The first number i s greater than second, so we changed their places:\n" + "{0}; {1}", a, b);
            }
            else
            {
                Console.WriteLine("The first number is smaller than the second.");
            }
        }
    }
}
