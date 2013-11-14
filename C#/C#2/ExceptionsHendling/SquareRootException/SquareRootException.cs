using System;
using System.Linq;

namespace SquareRootException
{
    class SquareRootException
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter integer number: ");
                uint n = uint.Parse(Console.ReadLine());
                double result = Math.Sqrt(n);

                Console.WriteLine(result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Good Bye!");
            }
        }
    }
}
