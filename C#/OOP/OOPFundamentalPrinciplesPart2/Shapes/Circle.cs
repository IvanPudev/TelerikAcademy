using System;
using System.Linq;

namespace Shapes
{
    class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Width = radius;
            this.Height = radius;
        }

        public override double CalculateSurface()
        {
            return Math.PI * this.Width * this.Height;
        }
    }
}
