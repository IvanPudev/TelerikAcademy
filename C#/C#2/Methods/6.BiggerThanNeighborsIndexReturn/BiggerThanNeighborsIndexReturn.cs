using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.BiggerThanNeighborsIndexReturn
{
    class BiggerThanNeighborsIndexReturn
    {
        static void CheckIfBigger(int[] array, int indexToCheck)
        {
            indexToCheck = indexToCheck - 1;
            if (indexToCheck == 0 && array[indexToCheck] > array[1])
            {
                Console.WriteLine(indexToCheck + 1);
            }
            else if (indexToCheck == array.Length && array[indexToCheck] > array[array.Length - 1])
            {
                Console.WriteLine(indexToCheck + 1);
            }
            else
                for (int i = 2; i < array.Length - 2; i++ )
                {
                    if (array[indexToCheck] > array[i - 1] && array[indexToCheck] > array[i + 1])
                    {
                        Console.WriteLine(indexToCheck +1);
                    }
                    else
                    {
                        Console.WriteLine(-1);
                    }
                }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter length of the array N: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter {0} element: ", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Enter the position of the number you want to check: ");
            int element = int.Parse(Console.ReadLine());
            CheckIfBigger(array, element);
        }
    }
}
