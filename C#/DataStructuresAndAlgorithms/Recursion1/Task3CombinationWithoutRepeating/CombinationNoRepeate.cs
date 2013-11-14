using System;
using System.Linq;

namespace Task3CombinationWithoutRepeating
{
    class CombinationNoRepeate
    {
        static void CombinationWithoutRepeating(int[] array, int index, int k, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (index >= k)
                {
                    Console.WriteLine(string.Join(" ", array));
                    return;
                }
                else
                {
                    array[index] = i;
                    CombinationWithoutRepeating(array, index + 1, k, i + 1);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter N = ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter K = ");
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[k];

            CombinationWithoutRepeating(array, 0, k, n);
        }
    }
}
