using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.ConvertAnyBaseSToAnyBaseD
{
    class Program
    {
        static string ConvertNum(string numberToConvert, byte fromNumeralSys, byte toNumeralSys)
        {
            StringBuilder result = new StringBuilder();
            return result.ToString();
        }
        static void Main(string[] args)
        {
            Console.Write("Enter numerical system you want to use [2, 36]: ");
            byte s = byte.Parse(Console.ReadLine());
            Console.Write("Enter number you want to convert: ");
            string number = Console.ReadLine();
            Console.Write("Enter numerical system you want to convert to [2, 36]: ");
            byte d = byte.Parse(Console.ReadLine());
            Console.WriteLine(ConvertNum(number, s, d));
        }
    }
}
