using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _5.CalculationOfN_xK_Div_N_K__
{
    class CalculationOfNFactorialxKFactorialDivNMinusKFaktorial
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number N > 1: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter integer number K > N: ");
            int k = int.Parse(Console.ReadLine());
            BigInteger factorialDifference = 1;
            BigInteger factorialK = 1;
            BigInteger factorialN = 1;

            if (1 < n && n < k)
            {
                for (int i = (k-n); i > 1; i--)
                {
                    factorialDifference *= i;
                }
                for (int i = 1; i <= k; i++)
                {
                    factorialK *= i;
                }
                for (int i = 1; i <= n; i++)
                {
                    factorialN *= i;
                }
                Console.WriteLine("N!*K!/(K-N)! = {0}", factorialK*factorialN/factorialDifference);
            }
            else
            {
                Console.WriteLine("invalit input.");
            }
        }
    }
}
