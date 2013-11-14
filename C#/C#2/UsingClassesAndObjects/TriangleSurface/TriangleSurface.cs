using System;
using System.Linq;

namespace TriangleSurface
{
    class TriangleSurface
    {
        static decimal SurfaceSideAltitude()
        {
            Console.Write("Enter length of the  side of the triangle a = ");
            decimal a = decimal.Parse(Console.ReadLine());
            Console.Write("Enter length of the altitude a of the triangle h = ");
            decimal h = decimal.Parse(Console.ReadLine());

            decimal triangleSurfase = 0;
            triangleSurfase = (a * h) / 2;

            return triangleSurfase;
        }

        static double SurfaceThreeSides()
        {
            Console.Write("Enter length of the  side of the triangle a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter length of the  side of the triangle b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter length of the  side of the triangle c = ");
            double c = double.Parse(Console.ReadLine());

            double triangleSurfase = 0;

            if (a + b > c) // Checking if triangle exists
            {
                double p = (a + b + c) / 2; 
                triangleSurfase = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            return triangleSurfase;
        }

        static double SurfaceSideASideBGama()
        {
            Console.Write("Enter length of the  side of the triangle a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter length of the  side of the triangle b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter value of the angle in radians between a and b (0,200) y = ");
            double angle = double.Parse(Console.ReadLine());
            double triangleSurfase = 0;

            triangleSurfase = (a * b) * Math.Sin(Math.PI * angle/ 180) / 2;

            return triangleSurfase;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("S = {0}", SurfaceSideAltitude());
            Console.WriteLine("S = {0}", SurfaceThreeSides());
            Console.WriteLine("S = {0}", SurfaceSideASideBGama());
        }
    }
}
