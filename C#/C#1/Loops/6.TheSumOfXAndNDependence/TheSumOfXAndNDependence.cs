using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _6.TheSumOfXAndNDependence
{
    class TheSumOfXAndNDependence
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number N > 1: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter integer number X > 0: ");
            int x = int.Parse(Console.ReadLine());
            double sumS = 1;
            BigInteger factorialN = 1;
            BigInteger pow = 1;

            if (n > 1 && x != 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                       factorialN *= j;
                       pow *= x; 
                    }
                    sumS += (double)(factorialN) / (double)(pow);
                    factorialN = 1;
                    pow = 1;
                }
                Console.WriteLine("S = 1 + 1!/X^1 + 2!/X^2 + ... + N!/X^N = {0}", sumS);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
