using System;
using System.Linq;
using System.Numerics;

namespace Task5
{
    class CatalanNumbers
    {
        static void Main(string[] args)
        {
            
            int input = int.Parse(Console.ReadLine());
            int n = input / 2;

            BigInteger divisible = 1;
            BigInteger divisor = 1;

            for (int i = 2 * n; i > n; i--)
            {
                divisible *= i;
            }
            for (int i = 1; i <= (n + 1); i++)
            {
                divisor *= i;
            }

            Console.WriteLine( divisible / divisor);
        }
    }
}