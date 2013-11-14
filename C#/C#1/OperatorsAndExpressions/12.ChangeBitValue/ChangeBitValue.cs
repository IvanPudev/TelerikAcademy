using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ChangeBitValue
{
    class ChangeBitValue
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter position: ");
            int position = int.Parse(Console.ReadLine());
            Console.Write("Enter value: ");
            int value = int.Parse(Console.ReadLine());
            int substitute = 1;
            if (value == 0)
            {
                int mask = ~( substitute << position );
                int result = number & mask;
                Console.WriteLine("The result is: {0}", result);
            }
            else
            {
                int mask = substitute << position ;
                int result = number | mask ;
                Console.WriteLine("The result is: {0}", result);
            }
        }
    }
}
