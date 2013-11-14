using System;
using System.Collections.Generic;
using System.Text;

namespace Variations
{
    class Variations
    {
        static void Variation(List<string> set, int N, int k, string combination)
        {
            if (k == 0)
            {
                Console.WriteLine(combination);
                return;
            }

            for (int i = 0; i < N; i++)
            {
                Variation(set, N, k - 1, combination + set[i] + " ");
            }
        }

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());

            List<string> set = new List<string>();

            set.Add("hi");
            set.Add("a");
            set.Add("b");

            Variation(set, N, K, "");
        }
    }
}
