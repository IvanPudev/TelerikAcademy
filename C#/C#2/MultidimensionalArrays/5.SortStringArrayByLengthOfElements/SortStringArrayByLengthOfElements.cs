using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.SortStringArrayByLengthOfElements
{
    class SortStringArrayByLengthOfElements
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of strings you want to arange N = ");
            int n = int.Parse(Console.ReadLine());
            string[] stringArray = new string[n];
            int[] lengthArray = new int[n];
            for (int index = 0; index < n; index++)
            {
                Console.Write("Enter {0} string: ", index + 1);
                stringArray[index] = Console.ReadLine();
            }

            for (int index = 0; index < n; index++)
            {
                lengthArray[index] = stringArray[index].Length;
            }

            Array.Sort(lengthArray, stringArray);

            Console.WriteLine("The aranged strings are:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(stringArray[i]);
            }
        }
    }
}
