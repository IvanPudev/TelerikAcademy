using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MultipliedIndexes
{
    class MultipliedIndexes
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];

            for (int index = 0; index < 20; index++)
            {
                array[index] = index * 5;
                Console.Write("{0} ", array[index]);
            }
            Console.WriteLine();
        }
    }
}
