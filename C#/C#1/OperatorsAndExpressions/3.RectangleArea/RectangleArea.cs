using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.RectangleArea
{
    class RectangleArea
    {
        static void Main(string[] args)
        {
            Console.Write("Enter rectangle's width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Enter rectangle's height: ");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("The rectangle's area is: {0}", width*height);
        }
    }
}
