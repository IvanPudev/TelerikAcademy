using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.FindGivvenSumInArray
{
    class FindGivvenSumInArray
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of the array you want to check n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter the sum (if exists in the array) you want to check S = ");
            int s = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter {0} element: ", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n - 1; i++)
            {
                int sum = 0;
                sum = array[i];
                int begin = i;
                for (int j = i + 1; j < n; j++)
                {
                    sum += array[j];
                    if (sum == s)
                    {
                        Console.Write("The sequence with S = {0} is: ", s);
                        for (int sumSeqNum = begin; sumSeqNum <= j; sumSeqNum++)
                        {
                            Console.Write(array[sumSeqNum] + " ");
                        }
                        Console.WriteLine();
                        return;
                    }
                }
                
            }

            Console.WriteLine("No sequence was found.");
        }
    }
}
