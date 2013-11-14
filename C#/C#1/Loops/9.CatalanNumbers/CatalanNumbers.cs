using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _9.CatalanNumbers
{
    class CatalanNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Catalan's number you want to calculate: ");
            int n = int.Parse(Console.ReadLine());
            BigInteger divisible = 1;
            BigInteger divisor = 1;

            for (int i = 2*n; i > n; i--)
            {
                divisible *= i;
            }
            for (int i = 1; i <= (n + 1); i++)
            {
                divisor *= i;
            }
            Console.WriteLine("The number is: {0}", divisible / divisor);
        }
    }
}
