using System;
using System.Collections.Generic;
using System.Linq;

namespace Euclidian3D
{
    class Path
    {
        private readonly List<Point3D> points = new List<Point3D>();

        public List<Point3D> Points
        {
            get { return points; }
        }

        public void Add(Point3D point)
        {
            points.Add(point);
        }

        public void Remove(Point3D point)
        {
            points.Remove(point);
        }
    }
}
