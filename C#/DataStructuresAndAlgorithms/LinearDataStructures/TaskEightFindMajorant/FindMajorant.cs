//The majorant of an array of size N is a value that occurs 
//in it at least N/2 + 1 times. Write a program to find the 
//majorant of given array (if exists).

using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskEightFindMajorant
{
    class FindMajorant
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>()
            { 1, 2, 2, 1, 1, 3, 3, 3, 4, 3, 3, 1, 1, 1, 1, 2 };

            Dictionary<int, int> refacturedList = new Dictionary<int, int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                int value = 0;
                if (!refacturedList.TryGetValue(sequence[i], out value))
                {
                    refacturedList.Add(sequence[i], 1);
                }
                else
                {
                    refacturedList[sequence[i]]++;
                }
            }

            var orderedList = refacturedList.OrderBy(pair => -pair.Value);


            if (orderedList.First().Value >= ((sequence.Count / 2) + 1))
            {
                Console.WriteLine("{0} is the majorant.", orderedList.First().Key);
            }
            else
            {
                Console.WriteLine("No majorant found.");
            }
        }
    }
}
