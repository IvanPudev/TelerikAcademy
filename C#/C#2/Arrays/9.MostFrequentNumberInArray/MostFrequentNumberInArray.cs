using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.MostFrequentNumberInArray
{
    class MostFrequentNumberInArray
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of the array you want to check for max sum sequence n = ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int count = 0;
            int maxCount = 1;
            int bestNum = 0;

            for (int index = 0; index < array.Length; index++)
            {
                Console.Write("Enter {0} element: ", index + 1);
                array[index] = int.Parse(Console.ReadLine());
            }

            for (int firstComparativeIndex = 0; firstComparativeIndex < n -1; firstComparativeIndex++)
            {
                count = 1;
                for (int secondComparativeIndex = firstComparativeIndex + 1; secondComparativeIndex < n; secondComparativeIndex++)
                {
                    if (array[firstComparativeIndex] == array[secondComparativeIndex])
                    {
                        count++;
                    }
                }
                if (count > maxCount)
                {
                    bestNum = array[firstComparativeIndex];
                    maxCount = count;
                }
            }
            
            Console.WriteLine("The most frequent number is {0}: {1} times. ",bestNum, maxCount);
        }
    }
}
