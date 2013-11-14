using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.CompareTwoArrays
{
    class CompareTwoArrays
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of the arrays you want to compare n = ");
            int n = int.Parse(Console.ReadLine());

            int[] array1 = new int[n];
            int[] array2 = new int[n];
            bool comperer = false;

            for (int index = 0; index < n; index++)
            {
                Console.Write("Enter {0} element of the first array: ", index + 1);
                array1[index] = int.Parse(Console.ReadLine());
            }

            for (int index = 0; index < n; index++)
            {
                Console.Write("Enter {0} element of the second array: ", index + 1);
                array2[index] = int.Parse(Console.ReadLine());
            }

            for (int index  = 0; index < n; index++)
            {
                if (array1[index] == array2[index])
                {
                    comperer = true;
                }
                else
                {
                    comperer = false;
                    break;
                }
            }

            if (comperer == true)
            {
                Console.WriteLine("The arrays are identical.");
            }
            else
            {
                Console.WriteLine("The arrays are not identical.");
            }
        }
    }
}
