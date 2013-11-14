using System;
using System.Linq;

namespace Shapes
{
    class Test
    {
        static void Main()
        {
            Shape[] arrayOfShapes = new Shape[] 
            {
                new Triangle(5, 3),
                new Rectangle(6, 3),
                new Circle(5)
            };

            foreach (Shape figure in arrayOfShapes)
            {
                Console.WriteLine(figure.CalculateSurface());
            }
        }
    }
}
