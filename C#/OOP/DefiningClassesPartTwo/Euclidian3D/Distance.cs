using System;
using System.Linq;

namespace Euclidian3D
{
    static class Distance
    {
        public static double CalcDistance(Point3D point1, Point3D point2)
        {
            return Math.Sqrt((point1.XCoordinate - point2.XCoordinate) * (point1.XCoordinate - point2.XCoordinate) +
                             (point1.YCoordinate - point2.YCoordinate) * (point1.YCoordinate - point2.YCoordinate) +
                             (point1.ZCoordinate - point2.ZCoordinate) * (point1.ZCoordinate - point2.ZCoordinate));
        }
    }
}
