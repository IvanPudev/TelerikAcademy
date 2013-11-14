using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.NumberOfNullsInFactorialEnd
{
    class NumberOfNullsInFactorialEnd
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number N for which you want to calculate\n" + "the nulls at the end of its factorial: ");
            int n = int.Parse(Console.ReadLine());
            int baseExponent = 5;
            int counter = 0;

            while (baseExponent <= n)
            {
                counter = counter + n / baseExponent;
                baseExponent *= 5;
            }
            Console.WriteLine("The number of nulls is: {0}.", counter);
        }
    }
}
