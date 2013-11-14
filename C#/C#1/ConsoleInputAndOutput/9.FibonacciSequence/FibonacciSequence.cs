using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _9.FibonacciSequence
{
    class FibonacciSequence
    {
        static void Main(string[] args)
        {
            BigInteger a = 0; 
            BigInteger b = 1; 
            BigInteger fibonacciSum = 0;
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(fibonacciSum);
                a = b;
                b = fibonacciSum;
                fibonacciSum = a + b;
            }
        }
    }
}
