using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _7.SumOfNFibonacciMembers
{
    class SumOfNFibonacciMembers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of fibonacci numbers,\n"+"which sum you want to calculate: ");
            int n = int.Parse(Console.ReadLine());
            BigInteger sum = 1;
            BigInteger firstEllement = 0;
            BigInteger secondEllement = 1;
            BigInteger nextEllement = 0;
            for (int i = 2; i < n; i++)
            {
                nextEllement = firstEllement + secondEllement;
                firstEllement = secondEllement;
                secondEllement = nextEllement;
                sum += nextEllement;
            }
            Console.WriteLine("The sum is: {0}", sum);
        }
    }
}
