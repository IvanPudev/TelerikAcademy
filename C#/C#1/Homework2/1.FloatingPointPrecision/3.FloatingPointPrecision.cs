using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.FloatingPointPrecision
{
    class Program
    {
        static void Main(string[] args)
        {
            float precision = 0.000001f;
            Console.WriteLine("Comparing floating-point numbers with precision 0.000001");
            Console.Write("Insert first number: ");
            float number1 = float.Parse(Console.ReadLine());
            Console.Write("Insert second number: ");
            float number2 = float.Parse(Console.ReadLine());
            Boolean compare = Math.Abs(number1 - number2) <= precision;
            Console.WriteLine(compare);
        }
    }
}
