using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.PointAndCircle
{
    class PointAndCircle
    {
        static void Main(string[] args)
        {
            Console.Write("Enter x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter y: ");
            double y = double.Parse(Console.ReadLine());
            if ((x * x + y * y) <= 25)
            {
                Console.WriteLine("The point({0};{1}) is in the circle(O;5)", x, y);
            }
            else
            {
                Console.WriteLine("The point({0};{1}) is not in the circle(O;5)", x, y);
            }
        }
    }
}
