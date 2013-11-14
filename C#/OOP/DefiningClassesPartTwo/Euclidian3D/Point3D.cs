using System;
using System.Linq;


namespace Euclidian3D
{
    public struct Point3D
    {
        private double xCoordinate;
        private double yCoordinate;
        private double zCoordinate;
        static readonly Point3D point0 = new Point3D(0,0,0); 

        public Point3D(double x, double y, double z)
            : this()
        {
            this.XCoordinate = x;
            this.YCoordinate = y;
            this.ZCoordinate = z;
        }

        public double XCoordinate
        {
            get { return this.xCoordinate; }
            private set { this.xCoordinate = value; }
        }

        public double YCoordinate
        {
            get { return this.yCoordinate; }
            private set { this.yCoordinate = value; }
        }

        public double ZCoordinate
        {
            get { return this.zCoordinate; }
            private set { this.zCoordinate = value; }
        }

        public static Point3D Point0
        {
            get { return point0; }
        }
        
        public override string ToString()
        {
            return string.Format("Point({0}, {1}, {2})", XCoordinate, YCoordinate, ZCoordinate);
        }

    }
}
