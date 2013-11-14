using System;
using System.Linq;
using System.IO;

namespace Euclidian3D
{
    static class PathStorage
    {
        public static Path ReadCoordinates(string fileName)
        {
            Path listOfPoints = new Path();
            using (StreamReader readFromFile = new StreamReader(fileName))
            {
                string line;
                while ((line = readFromFile.ReadLine()) != null)
                {
                    string[] coordinates = line.Split(new string[] {",", "(", ")"," ", "Point"}, StringSplitOptions.RemoveEmptyEntries);
                    double x = double.Parse(coordinates[0]);
                    double y = double.Parse(coordinates[1]);
                    double z = double.Parse(coordinates[2]);
                    Point3D filledPoint = new Point3D(x,y,z);
                    listOfPoints.Add(filledPoint);
                }
            }
            return listOfPoints;
        }

        public static void WriteCoordinates(string fileName, Path points)
        {
            using (StreamWriter writeToFile = new StreamWriter(fileName))
            {
                foreach (var point in points.Points)
                {
                    writeToFile.WriteLine(point);
                }
            }
        }
    }
}
