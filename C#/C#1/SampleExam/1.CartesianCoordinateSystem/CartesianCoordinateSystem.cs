using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.CartesianCoordinateSystem
{
    class CartesianCoordinateSystem
    {
        static void Main(string[] args)
        {
            double pointX = double.Parse(Console.ReadLine());
            double pointY = double.Parse(Console.ReadLine());

            if (pointX > 0 && pointY > 0)
            {
                Console.WriteLine("1");
            }
            else if (pointX < 0 && pointY > 0)
            {
                Console.WriteLine("2");
            }
            else if (pointX < 0 && pointY < 0)
            {
                Console.WriteLine("3");
            }
            else if (pointX > 0 && pointY < 0)
            {
                Console.WriteLine("4");
            }
            else if (pointY == 0 && pointX != 0)
            {
                Console.WriteLine("6");
            }
            else if (pointX == 0 && pointY != 0)
            {
                Console.WriteLine("5");
            }
            else if (pointX == 0 && pointY == 0)
            {
                Console.WriteLine("0");
            }
        }
    }
}
