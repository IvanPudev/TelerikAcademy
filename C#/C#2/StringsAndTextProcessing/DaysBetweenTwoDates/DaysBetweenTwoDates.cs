using System;
using System.Globalization;
using System.Linq;

//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.

namespace DaysBetweenTwoDates
{
    class DaysBetweenTwoDates
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two dates in format: d.MM.yyyy:");
            Console.Write("First date: ");
            string firstDate = Console.ReadLine();
            Console.Write("Second date: ");
            string secondDate = Console.ReadLine();
            string format = "d.MM.yyyy";

            DateTime firstDateParse = DateTime.ParseExact(firstDate, format, CultureInfo.InvariantCulture);
            DateTime secondDateParse = DateTime.ParseExact(secondDate, format, CultureInfo.InvariantCulture);

            Console.WriteLine("Distance: {0}", (secondDateParse - firstDateParse).TotalDays);
        }
    }
}
