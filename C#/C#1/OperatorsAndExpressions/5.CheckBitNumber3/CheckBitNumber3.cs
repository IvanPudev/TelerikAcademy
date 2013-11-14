using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.CheckBitNumber3
{
    class CheckBitNumber3
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an enteger: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("The third digit of the number in binary code is: {0}",(number >> 3 & 1)); // Moving the third bit to the right and comparing with logical "and" if it equals 1
        }
    }
}
