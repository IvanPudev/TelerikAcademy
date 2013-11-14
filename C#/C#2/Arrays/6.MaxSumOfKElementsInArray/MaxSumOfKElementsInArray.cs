using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.MaxSumOfKElementsInArray
{
    class MaxSumOfKElementsInArray
    {
        static void Main(string[] args)
        {

            Console.Write("Enter length N of the array: ");
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            Console.Write("Enter how many elements K (K<N) you want to check for max Sum: ");
            int k = int.Parse(Console.ReadLine());

            long sum = 0;

            for (int index = 0; index < n; index++)
            {
                Console.Write("Enter {0} element: ", index + 1);
                array[index] = int.Parse(Console.ReadLine());
            }

            Array.Sort(array);

            for (int index = n - 1; index >= n - k; index--)
            {
                sum += array[index];
            }

            Console.WriteLine("The max Sum from {0} elements in the array is: {1}", k, sum);
        }
    }
}
