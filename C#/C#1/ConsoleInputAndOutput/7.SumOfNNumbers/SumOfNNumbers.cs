using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.SumOfNNumbers
{
    class SumOfNNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number n for number to be calculated: ");
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                Console.Write("Enter number for calculatig: ");
                double number = double.Parse(Console.ReadLine());
                sum = sum + number;
            }
            Console.WriteLine("The sum of calculated numbers is: {0}", sum);
        }
    }
}
