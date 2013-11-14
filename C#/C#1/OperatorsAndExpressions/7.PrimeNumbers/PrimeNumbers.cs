using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.PrimeNumbers
{
    class PrimeNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer number smaller than 100: ");
            int number = int.Parse(Console.ReadLine());
            int maxDivider = (int)Math.Sqrt(number);
            for ( int i = 2; i <= maxDivider; i++)
            {
                if (number % i == 0)
                {
                    Console.WriteLine("The number is composite");
                    return;
                }
            }
            Console.WriteLine("The number is prime");
        }
    }
}
