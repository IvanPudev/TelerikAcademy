using System;
using System.Collections.Generic;

namespace SetPermutations
{
    public class Permutations
    {
        static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
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
            int N = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                numbers.Add(i);
            }

            Permutation(numbers, 0);
        }
    }
}
