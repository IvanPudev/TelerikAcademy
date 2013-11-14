using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main(string[] args)
        {
            Console.Write("Enter coefficient a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter coefficient b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter coefficient c: ");
            double c = double.Parse(Console.ReadLine());
            double x1, x2, d;

            if (a == 0)
            {
                Console.WriteLine("The equation is not quadratic.");
            }
            else
            {
                d = Math.Pow(b, 2) - 4 * a * c;
                if (d < 0)
                {
                    Console.WriteLine("The equation has no real roots.");
                }
                else if (d == 0)
                {
                    x1 = -b / 2 * a;
                    Console.WriteLine("The discriminant is 0. The root is x = {0}", x1);
                }
                else if (d > 0)
                {
                    x1 = (-b + d) / 2 * a;
                    x2 = (-b - d) / 2 * a;
                    Console.WriteLine("The roots of the equation are x1 = {0} and x2 = {1}", x1, x2);
                }


            }
        }
    }
}
