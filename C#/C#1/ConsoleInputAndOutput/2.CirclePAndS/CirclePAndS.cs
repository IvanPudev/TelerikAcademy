using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.CirclePAndS
{
    class CirclePAndS
    {
        static void Main(string[] args)
        {
            Console.Write("Enter circle radius r = ");
            double radius = double.Parse(Console.ReadLine());
            double perimeter, area;
            perimeter = 2 * Math.PI * radius;
            area = Math.PI * radius * radius;
            Console.WriteLine("The perimeter of the circle is P = {0}", perimeter);
            Console.WriteLine("The area of the circle is S = {0}", area);
        }
    }
}
