//Write a program that removes from given sequence all numbers
//that occur odd number of times. Example:
//{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}

using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskSixRemoveElementsWithOddCount
{
    class RemoveElementsWithOddCount
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Dictionary<int, int> oddCountElements = new Dictionary<int, int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (!oddCountElements.Keys.Contains(sequence[i]))
                {
                    oddCountElements.Add(sequence[i], 1);
                }
                else
                {
                    oddCountElements[sequence[i]]++;
                }
            }

            sequence.RemoveAll(elements => oddCountElements[elements] % 2 != 0);

            Console.WriteLine("The secuence without odd repeated elements is:");
            foreach (int element in sequence)
            {
                Console.Write("{0} ", element);
            }
            Console.WriteLine();
        }
    }
}
