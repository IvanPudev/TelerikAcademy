using System;

namespace Task2LevensteinDistance
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(LevenshteinDistance.Compute("aunt", "ant"));
            Console.WriteLine(LevenshteinDistance.Compute("Sam", "Samantha"));
            Console.WriteLine(LevenshteinDistance.Compute("matrix", "metrix"));
            Console.WriteLine(LevenshteinDistance.Compute("one", "six"));
            Console.WriteLine(LevenshteinDistance.Compute("never", "ever"));
        }
    }
}

