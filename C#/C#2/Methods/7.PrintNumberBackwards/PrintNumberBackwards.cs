using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.PrintNumberBackwards
{
    class PrintNumberBackwards
    {
        static void ReverseNumber(decimal enteredNumber)
        {
            char[] reversedNumber = enteredNumber.ToString().ToCharArray();
            Array.Reverse(reversedNumber);
            Console.WriteLine(reversedNumber);
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number you want to reverse: ");
            decimal number = decimal.Parse(Console.ReadLine());
            Console.Write("The reversed number is: ");
            ReverseNumber(number);
        }
    }
}
