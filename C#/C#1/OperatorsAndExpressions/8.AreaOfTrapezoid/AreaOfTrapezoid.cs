using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.AreaOfTrapezoid
{
    class AreaOfTrapezoid
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the down side of the trapezoid a= ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter the upper side of the trapezoid b= ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter the height of the trapezoid h= ");
            double h = double.Parse(Console.ReadLine());
            double area = (a + b) * h / 2;
            if (a > 0 && b > 0 && h > 0)
            {
                Console.WriteLine("The area of trapezoid with sides {0}, {1} and height {2} is: {3}", a, b, h, area);
            }
            else 
            {
                Console.WriteLine("Not a valid ");
            }
        }
    }
}
