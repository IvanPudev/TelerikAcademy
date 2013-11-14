using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.CircleRectangleAndPoint
{
    class CircleRectangleAndPoint
    {
        static void Main(string[] args)
        {
            int circleX = 1;
            int circleY = 1;
            int circleR = 3;
            int rectTopY = 1;
            int rectBottomY = -1;
            int rectLeftX = -1;
            int rectRightX = 5;
            Console.Write("Enter x= ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter y= ");
            int y = Convert.ToInt32(Console.ReadLine());
            int checkX = x - circleX;
            int checkY = y - circleY;
            if ((Math.Pow(checkX, 2) + Math.Pow(checkY, 2)) <= Math.Pow(circleR, 2))
            {
                if (((x < rectLeftX) || (x > rectRightX)) && ((y > rectTopY) || (y < rectBottomY)))
                {
                    Console.WriteLine("The point with coordinates [{0};{1}] is in the circle [1,1;3]", x, y);
                    Console.WriteLine("and out of the rectangle [top=1;left=-1;lenth=6;height=2]");
                }
                else
                {
                    Console.WriteLine("The point with coordinates [{0};{1}] is in the circle [1,1;3]", x, y);
                    Console.WriteLine("and is in the rectangle [top=1;left=-1;lenth=6;height=2]");
                }
            }
            else
            {
                if (((x < rectLeftX) || (x > rectRightX)) && ((y > rectTopY) || (y < rectBottomY)))
                {
                    Console.WriteLine("The point with coordinates [{0};{1}] is not in the circle [1,1;3]", x, y);
                    Console.WriteLine("and out of the rectangle [top=1;left=-1;lenth=6;height=2]");
                }
                else
                {
                    Console.WriteLine("The point with coordinates [{0};{1}] is not in the circle [1,1;3]", x, y);
                    Console.WriteLine("and is in the rectangle [top=1;left=-1;lenth=6;height=2]");
                }
            }
        }
    }
}
