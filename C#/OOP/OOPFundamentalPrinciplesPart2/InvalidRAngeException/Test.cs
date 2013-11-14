using System;
using System.Linq;

namespace InvalidRAngeException
{
    class Test
    {
        static void Main()
        {
            Console.Write("Enter number between 0 and 10: ");
            int number = int.Parse(Console.ReadLine());
            try
            {
                if (number < 0 || number > 10)
                {
                    throw new InvalidRangeException<int>("Incorect input.", 0, 10);
                }
                Console.WriteLine("Correct input.");
            }
            catch (InvalidRangeException<int> exception)
            {
                Console.WriteLine("{2} It should be between {0} and {1}.", exception.Begin, exception.End, exception.Message);
            }

            Console.Write("Enter date between 1.1.2000 and 31.12.2012(Year.Month.Day): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            try
            {
                if (date < new DateTime(2000, 1, 1) || date > new DateTime(2012, 12, 31))
                {
                    throw new InvalidRangeException<DateTime>("Date is invalid!", new DateTime(2000, 1, 1), new DateTime(2012, 12, 31));
                }
                Console.WriteLine("Date correct!");
            }
            catch (InvalidRangeException<DateTime> exception)
            {
                Console.WriteLine("{2} It should be between {0} and {1}.", exception.Begin.ToShortDateString(), exception.End.ToShortDateString(), exception.Message);
            }
        }
    }
}
