using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _4.DivisionOfNAndKFactorial
{
    class DivisionOfNAndKFactorial
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number N > 1: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter integer number K (1 < K < N):");
            int k = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            if (1 < k && k < n)
            {
                for (int i = n ; i > k; i--)
                {
                    factorial *= i;
                }
                Console.WriteLine("N!/K! = {0}!/{1}! = {2}", n, k, factorial);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
