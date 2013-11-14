using System;
using System.Linq;

namespace Shapes
{
    abstract class Shape
    {
        protected double width;
        protected double height;

        public double Width
        {
            get { return this.width; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value can not be negative or zero.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value can not be negative or zero.");
                }
                this.height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
