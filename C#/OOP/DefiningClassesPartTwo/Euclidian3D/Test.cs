﻿using System;
using System.Linq;

//Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
//Implement the ToString() to enable printing a 3D point.
//Add a private static read-only field to hold the start of the coordinate system –
//the point O{0, 0, 0}. Add a static property to return the point O.
//Write a static class with a static method to calculate the distance between two points in the 3D space.
//Create a class Path to hold a sequence of points in the 3D space. 
//Create a static class PathStorage with static methods to save and 
//load paths from a text file. Use a file format of your choice.

namespace Euclidian3D
{
    class Test
    {
        static void Main()
        {
            Point3D point1 = new Point3D(2, 4, 5);
            Point3D point2 = new Point3D(1, 6, 8);
            
            Console.WriteLine(point1.ToString());
            Console.WriteLine(point2.ToString());
            Console.WriteLine("The distance between points is: {0}.", Distance.CalcDistance(point1, point2));
            Console.WriteLine(Point3D.Point0);

            string inputFile = "..//..//readpoints.txt";
            string outputFile = "..//..//results.txt";
            
            PathStorage.WriteCoordinates(outputFile, PathStorage.ReadCoordinates(inputFile));
            
        }
    }
}
