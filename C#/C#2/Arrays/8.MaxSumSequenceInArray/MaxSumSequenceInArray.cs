using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.MaxSumSequenceInArray
{
    class MaxSumSequenceInArray
    {
        static void Main(string[] args)      //Kadane's Algorithm
        {
            Console.Write("Enter the length of the array you want to check for max sum sequence n = ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int maxSoFar = array[0];
            int maxEndingHere = array[0];
            int begin = 0;
            int beginTemp = 0;
            int end = 0;

            for (int index = 0; index < array.Length; index++)
            {
                Console.Write("Enter {0} element: ", index + 1);
                array[index] = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i < array.Length; i++)
            {
                maxEndingHere += array[i];
                if (array[i] > maxEndingHere)
                {
                    maxEndingHere = array[i];
                    beginTemp = i;
                }
                if (maxEndingHere > maxSoFar)
                {
                    maxSoFar = maxEndingHere;
                    begin = beginTemp;
                    end = i;
                }
            }

            Console.Write("The sequence with max sum is: ");
            for (int i = begin; i <= end; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
