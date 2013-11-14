using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.MinAndMaxInSequence
{
    class MinAndMaxInSequence
    {
        static void Main(string[] args)
        {
            int max = 0, min, number;

            Console.Write("Enter the number of numbers you want to check: ");
            int n = int.Parse(Console.ReadLine());
            min = n;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter integer: ");
                number = int.Parse(Console.ReadLine());
                if (number > max)
                {
                    max = number;
                 
                }
                if (number < min)
                {
                    min = number;
                }
            }
            Console.WriteLine("The MAX number is {0} and the MIN number is {1}.", max, min);
        }
    }
}
