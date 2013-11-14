using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1NestedLoops
{
    class Program
    {
        static void NestedLoopSimulation(int[] array,int start, int end)
        {

            for (int i = 1; i <= end; i++)
            {
                if (start == end)
                {
                    Console.WriteLine(string.Join(" ", array));
                    return;
                }
                else
                {
                    array[start] = i;
                    NestedLoopSimulation(array, start +1, end);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter N = ");
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            NestedLoopSimulation(array, 0, n);
        }
    }
}
