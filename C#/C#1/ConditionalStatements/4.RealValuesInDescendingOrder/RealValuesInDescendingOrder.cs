using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.RealValuesInDescendingOrder
{
    class RealValuesInDescendingOrder
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first integer: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter third integer: ");
            double c = double.Parse(Console.ReadLine());
         
            if (a < b)
            {
                if (b < c)
                {
                    Console.WriteLine("The descending order of the numbers is : {0}; {1}; {2}", c, b, a);
                }
                else if (a < c)
                {
                    Console.WriteLine("The descending order of the numbers is : {0}; {1}; {2}", b, c, a);
                }
                else
                {
                    Console.WriteLine("The descending order of the numbers is : {0}; {1}; {2}", b, a, c);
                }
            }
            else if (a < c)
            {
                if (b < c)
                {
                    Console.WriteLine("The descending order of the numbers is : {0}; {1}; {2}", c, a, b);
                }

            }
            else if (a > c)
            {
                if (b > c)
                {
                    Console.WriteLine("The descending order of the numbers is : {0}; {1}; {2}", a, b, c);
                }
                else 
                {
                    Console.WriteLine("The descending order of the numbers is : {0}; {1}; {2}", a, c, b);
                }
            }
        }
    }
}
