using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.DividedBy5NumbersInArrea
{
    class DividedBy5NumbersInArrea
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            int counter = 0;
            if (firstNumber < secondNumber)
            {
                for (int i = firstNumber; i <= secondNumber; i++)
                {
                    if (i % 5 == 0)
                        counter++;
                }
                Console.WriteLine("There are {0} numbers between the first and second one,", counter);
                Console.WriteLine("that can be divided by 5 and the result is 0.");
            }
            else 
            {
                for (int i = secondNumber; i <= firstNumber; i++)
                {
                    if (i % 5 == 0)
                        counter++;
                }
                Console.WriteLine("There are {0} numbers between the first and second one,", counter);
                Console.WriteLine("that can be divided by 5 and the result is 0.");
            }
        }
    }
}
