using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.MaxNumberWithoutIf
{
    class MaxNumberWithoutIf
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            double secondNumber = double.Parse(Console.ReadLine());
            Console.WriteLine("The bigger number between {0} and {1} is {2}", firstNumber, secondNumber, Math.Max(firstNumber,secondNumber));
        }
    }
}
