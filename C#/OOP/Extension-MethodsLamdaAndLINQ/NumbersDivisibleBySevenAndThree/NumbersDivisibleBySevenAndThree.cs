using System;
using System.Linq;

//Write a program that prints from given array of integers all
//numbers that are divisible by 7 and 3. Use the built-in extension
//methods and lambda expressions. Rewrite the same with LINQ.

namespace NumbersDivisibleBySevenAndThree
{
    class NumbersDivisibleBySevenAndThree
    {
        static void Main()
        {
            int[] array = new int[] { 1, 5, 21, 42, 18, 7, 3, 63, -21, -42 };
            var result = array.Where(x => x % 21 == 0).ToArray();
            Console.WriteLine(string.Join(", ", result));

            var resultLinq = from integer in array
                             where integer % 21 == 0
                             select integer;
            Console.WriteLine(string.Join(", ", resultLinq));
        }
    }
}
