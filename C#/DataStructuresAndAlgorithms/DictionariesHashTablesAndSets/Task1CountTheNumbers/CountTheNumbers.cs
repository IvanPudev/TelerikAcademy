using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1CountTheNumbers
{
    class CountTheNumbers
    {
        static void Main(string[] args)
        {
            double[] arr = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5};
            SortedDictionary<double, int> sortedDict = new SortedDictionary<double, int>();

            foreach (var element in arr)
            {
                if (sortedDict.ContainsKey(element))
                {
                    sortedDict[element]++;
                }
                else
                {
                    sortedDict.Add(element, 1);
                }
            }

            foreach (var pair in sortedDict)
            {
                Console.WriteLine("Number {0} -> {1} times.", pair.Key, pair.Value);
            }
        }
    }
}
