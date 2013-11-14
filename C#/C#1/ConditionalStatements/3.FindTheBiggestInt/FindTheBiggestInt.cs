using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.FindTheBiggestInt
{
    class FindTheBiggestInt
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first integer: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int c = int.Parse(Console.ReadLine());

            if ( a < b )
            {
                if (b < c)
                {
                    Console.WriteLine("The biggest integer number is: {0}", c);
                }
                else
                {
                    Console.WriteLine("The biggest integer number is: {0}", b);
                }
            }
            else if (a < c)
            {
                Console.WriteLine("The biggest integer number is: {0}", c);
            }
            else
            {
                Console.WriteLine("The biggest integer number is: {0}", a);
            }
        }
    }
}
