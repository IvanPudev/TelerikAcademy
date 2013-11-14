using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.GreatestComonDivisorOfTwoNumbers
{
    class GreatestCommonDivisorOfTwoNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            int switcher = 0;
            int result = 0;

            if (secondNumber > firstNumber)
            {
                switcher = firstNumber;
                firstNumber = secondNumber;
                secondNumber = switcher;
            }
            do
            {
                result = firstNumber % secondNumber;
                firstNumber = secondNumber;
                secondNumber = result;
            } while (result != 0);
            Console.WriteLine("The greatest common divisor is: {0}", firstNumber);
        }
    }
}
