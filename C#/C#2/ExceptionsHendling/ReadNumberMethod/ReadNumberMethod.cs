using System;
using System.Linq;

namespace ReadNumberMethod
{
    class ReadNumberMethod
    {
        static int ReadNumber(int start, int end)
        {
            int n = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter {0} number: ", i + 1);
                n = int.Parse(Console.ReadLine());
                if (n < start || n > end)
                {
                    throw new ArgumentOutOfRangeException();
                }
                start = n;
            }
            return n;
        }
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            Console.WriteLine("Enter 10 int numbers (0 < n < 101) \nand each next number must be bigger than previous.");

            try
            {
                ReadNumber(start, end);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Not a valid entry.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Element is not integer.");
            }
            finally 
            {
                Console.WriteLine("Start over and try again.");
            }
        }
    }
}
