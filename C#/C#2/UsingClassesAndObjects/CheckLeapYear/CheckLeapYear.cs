using System;
using System.Linq;

namespace CheckLeapYear
{
    class CheckLeapYear
    {
        static void Main(string[] args)
        {
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine("The year {0} is leap.", year);
            }
            else
            {
                Console.WriteLine("The year is not leap.");
            }
        }
    }
}
