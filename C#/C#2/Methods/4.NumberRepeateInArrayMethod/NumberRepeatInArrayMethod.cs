using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.NumberRepeatInArrayMethod
{
    class NumberRepeatInArrayMethod
    {
        static decimal NumberRepeat(decimal[] array, decimal numberChecked)
        {
            int counter = 0;
            for (int index = 0; index < array.Length; index++)
            {
                if (numberChecked == array[index])
                {
                    counter++;
                }
            }
            return counter;
        }
        static void Main(string[] args)
        {
            decimal[] array = { 3, 5, 6, 7, 8, 4, 4, 2, 5, 6, 7, 3, 4, 2, 4, 4, 8, 5, 4, 2 };
            foreach (int index in array)
            {
                Console.Write("{0} ",array[index]);
            }
            Console.WriteLine();
            Console.Write("Enter number you want to check for appearance: ");
            decimal number = decimal.Parse(Console.ReadLine());
            Console.WriteLine("The number {0} is appearing {1} times in the array.", number, NumberRepeat(array, number));
        }
    }
}
