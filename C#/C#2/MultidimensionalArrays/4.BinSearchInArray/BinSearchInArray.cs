using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.BinSearchInArray
{
    class BinSearchInArray
    {
        static void Main(string[] args)
        {
            Console.Write("Enter length of the array N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter integer you want to compare K = ");
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int searchedElement = 0;

            for (int index = 0; index < n; index++)
            {
                Console.Write("Enter {0} element: ", index + 1);
                array[index] = int.Parse(Console.ReadLine());
            }

            Array.Sort(array);

            if (array[0] <= k && k <= array[n - 1])
            {
                int indexSearchedElement = Array.BinarySearch(array, k);
                if (indexSearchedElement >= 0)
                {
                    searchedElement = array[indexSearchedElement];
                }
                else
                {
                    searchedElement = array[~indexSearchedElement - 1];
                }
                Console.WriteLine("The searched element is: {0}", searchedElement);
            }
            else
            {
                Console.WriteLine(" The integer K is not valid.");
            }
        }
    }
}
