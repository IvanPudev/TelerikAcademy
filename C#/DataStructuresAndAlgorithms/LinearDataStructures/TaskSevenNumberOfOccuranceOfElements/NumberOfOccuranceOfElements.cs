//Write a program that finds in given array of integers 
//(all belonging to the range [0..1000]) how many times each of them occurs.
//Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
//2 -> 2 times
//3 -> 4 times
//4 -> 3 times

using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskSevenNumberOfOccuranceOfElements
{
    class NumberOfOccuranceOfElements
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            Dictionary<int, int> orderedNumbers = new Dictionary<int, int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                int number = sequence[i];

                int count = sequence.FindAll(x => x == number).Count;

                if (!orderedNumbers.ContainsKey(number))
                {
                    orderedNumbers.Add(number, count);
                }
            }

            foreach (var number in orderedNumbers)
            {
                Console.WriteLine("Number: {0} -> {1} times", number.Key, number.Value);
            }
        }
    }
}
