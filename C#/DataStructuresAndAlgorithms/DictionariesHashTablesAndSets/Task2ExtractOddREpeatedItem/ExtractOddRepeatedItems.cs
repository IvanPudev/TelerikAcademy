using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2ExtractOddREpeatedItem
{
    class ExtractOddRepeatedItems
    {
        static void Main(string[] args)
        {
            string[] arr = {"C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            SortedDictionary<string, int> dict = new SortedDictionary<string, int>();

            foreach (var element in arr)
            {
                if (dict.ContainsKey(element))
                {
                    dict[element]++;
                }
                else
                {
                    dict.Add(element, 1);
                }
            }

            foreach (var pair in dict)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.WriteLine(pair.Key);
                }
            }
        }
    }
}
