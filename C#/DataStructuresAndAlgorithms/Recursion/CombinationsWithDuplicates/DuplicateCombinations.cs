using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsWithDuplicates
{
    class DuplicateCombinations
    {
        static void Combination(int count, int N, int k, string combination)
        {
            if (k == 0)
            {
                Console.WriteLine(combination);
                return;
            }

            for (int i = count; i <= N; i++)
            {
                Combination(i, N, k - 1, combination + i + " ");
            }
        }

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());

            Combination(1, N, K, "");
        }
    }
}
