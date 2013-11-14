using System;
using System.Collections.Generic;
using System.Text;

namespace SetPermutations
{
    public class Permutations
    {
        static HashSet<string> uniquePermutations = new HashSet<string>();
        static StringBuilder result = new StringBuilder();

        static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                result.Append(list[i] + " ");
            }

            if (uniquePermutations.Contains(result.ToString()))
            {
                result.Clear();
                return;
            }

            uniquePermutations.Add(result.ToString());
            Console.WriteLine(result.ToString());
            result.Clear();
        }

        static void Permutation(List<int> list, int pointer)
        {
            if (pointer == list.Count)
            {
                PrintList(list);
                return;
            }

            for (int i = pointer; i < list.Count; i++)
            {
                List<int> permutation = new List<int>(list);

                permutation[pointer] = list[i];
                permutation[i] = list[pointer];

                Permutation(permutation, pointer + 1);
            }
        }

        static void Main()
        {
            List<int> numbers = new List<int>() {1,3,5,5};

            Permutation(numbers, 0);

            Console.WriteLine("Massive test not efficient way but works for smaller sets");

            numbers = new List<int>() { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5};

            //not efficient
            Permutation(numbers, 0);
        }
    }
}
