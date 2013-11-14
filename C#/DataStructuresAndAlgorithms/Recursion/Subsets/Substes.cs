using System;
using System.Collections.Generic;

namespace Subsets
{
    class Substes
    {
        static void Variation(List<string> set, int count, int N, int k, string combination)
        {
            if (k == 0)
            {
                Console.WriteLine(combination);
                return;
            }

            for (int i = count; i < N; i++)
            {
                Variation(set, i + 1, N, k - 1, combination + set[i] + " ");
            }
        }

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());

            List<string> set = new List<string>();

            set.Add("test");
            set.Add("rock");
            set.Add("fun");

            Variation(set,0, N, K, "");
        }
    }
}
