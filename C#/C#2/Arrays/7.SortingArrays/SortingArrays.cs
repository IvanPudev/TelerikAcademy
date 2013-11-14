using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.SortingArrays
{
    class SortingArrays
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of the array you want to sort n = ");
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];
            int tempValue = 0;
            for (int index = 0; index < n; index++)
            {
                Console.Write("Enter {0} element: ", index + 1);
                array[index] = int.Parse(Console.ReadLine());
            }

            for (int index = 0; index < array.Length; index++)
            {
                int minNum = index;
                for (int check = index + 1; check < array.Length; check++)
                {
                    if (array[check] < array[minNum])
                    {
                        minNum = check;
                    }
                }
                tempValue = array[index];
                array[index] = array[minNum];
                array[minNum] = tempValue;
            }

            Console.Write("The sorted array is: ");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write("{0} ", array[index]);
            }
            Console.WriteLine();
        }
    }
}
