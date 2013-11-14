using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of the first array n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter the length of the second array m = ");
            int m = int.Parse(Console.ReadLine());
            
            char[] array1 = new char[n];
            char[] array2 = new char[m];
            int arrayLength = 0;
            byte checker = 0;

            for (int index = 0; index < n; index++)
            {
                Console.Write("Enter {0} element of the first array: ", index + 1);
                array1[index] = char.Parse(Console.ReadLine());
            }

            for (int index = 0; index < m; index++)
            {
                Console.Write("Enter {0} element of the second array: ", index + 1);
                array2[index] = char.Parse(Console.ReadLine());
            }

            if (n > m)
            {
                arrayLength = m;
            }
            else
            {
                arrayLength = n;
            }

            for (int index = 0; index < arrayLength; index++)
            {
                if (array1[index] < array2[index])
                {
                    checker = 1;
                }
                else if (array1[index] > array2[index])
                {
                    checker = 2;
                }
                else
                {
                    checker = 3;
                } 
            }

            if (checker == 1)
            {
                Console.WriteLine("The first array is earlier lexicographically.");
            }
            else if (checker == 2)
            {
                Console.WriteLine("The second array is earlier lexicographically.");
            }
            else if (checker == 3 && n < m)
            {
                Console.WriteLine("The first array is earlier lexicographically.");
            }
            else if (checker == 3 && n > m)
            {
                Console.WriteLine("The second array is earlier lexicographically.");
            }
            else if (checker == 3 && m == n)
            {
                Console.WriteLine("The arrays are equal lexicographically.");
            }
        }
    }
}
