using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MaxSequenceOfEqualElementsInArray
{
    class MaxSequenceOfEqualElementsInArray
    {
        static void Main(string[] args)
        {
            Console.Write("Enter length of the array you want to check for subarrays: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int beginSubArray = 0, lengthSubArray = 0, bestBeginSubArray = 0, bestLengthSubArray = 1;
            
            for (int index = 0; index < n; index++)
            {
                Console.Write("Enter {0} element: ", index + 1);
                array[index] = int.Parse(Console.ReadLine());
            }

            for (int index = 0; index < array.Length - 1; index++)
            {
                if (array[index] == array[index + 1])
                {
                    lengthSubArray++;
                    if (lengthSubArray > bestLengthSubArray)
                    {
                        bestLengthSubArray = lengthSubArray;
                        bestBeginSubArray = beginSubArray;
                    }
                }
                else
                {
                    lengthSubArray = 1;
                    beginSubArray = index + 1;
                }
            }

            Console.Write("The longest subarray is: ");
            for (int index = bestBeginSubArray; index < bestBeginSubArray + bestLengthSubArray; index++)
            {
                Console.Write(array[index]);
            }
            Console.WriteLine();
        }
    }
}
