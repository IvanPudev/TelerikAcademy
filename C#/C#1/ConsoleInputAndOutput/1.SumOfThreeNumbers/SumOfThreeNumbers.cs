using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SumOfThreeNumbers
{
    class SumOfThreeNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number a: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter integer number b: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter integer number c: ");
            int thirdNumber = int.Parse(Console.ReadLine());
            uint sum = (uint)( firstNumber + secondNumber + thirdNumber);
            Console.WriteLine("The sun of the three numbers a + b + c = {0}", sum);
        }
    }
}
