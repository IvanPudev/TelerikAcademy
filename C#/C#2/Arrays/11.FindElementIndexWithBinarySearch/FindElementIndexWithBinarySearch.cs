using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.FindElementIndexWithBinarySearch
{
    class FindElementIndexWithBinarySearch
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of sorted array you want to check n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter the element, which index you want to know: ");
            int element = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int minIndex = 0;
            int maxIndex = n - 1;
            int midIndex = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter {0} element: ", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }

            while (maxIndex >= minIndex)
            {
                midIndex = (maxIndex + minIndex)/ 2;
                if (array[midIndex] > element)
                {
                    maxIndex = midIndex - 1;
                }
                else if (array[midIndex] < element)
                {
                    minIndex = midIndex + 1;
                }
                else
                {
                    Console.WriteLine("The index of the number {0} is {1}.", element, midIndex);
                    break;
                }
            }
        }
    }
}