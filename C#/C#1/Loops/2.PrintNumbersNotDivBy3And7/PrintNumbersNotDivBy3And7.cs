using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.PrintNumbersNotDivBy3And7
{
    class PrintNumbersNotDivBy3And7
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer N = ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (i % 21 != 0)
                {
                    Console.WriteLine(i); 
                }
            }
        }
    }
}
