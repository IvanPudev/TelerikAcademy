using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.TheGreatestAmongst5Variables
{
    class TheGreatestAmongst5Variables
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first variable: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter second variable: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter third variable: ");
            double c = double.Parse(Console.ReadLine());
            Console.Write("Enter forth variable: ");
            double d = double.Parse(Console.ReadLine());
            Console.Write("Enter fifth variable: ");
            double e = double.Parse(Console.ReadLine());

            for (int i = 0; i < 5; i++)
            {
                if (a < b)
                {
                    a = b;
                    b = c;
                    c = d;
                    d = e;
                }
            }
            Console.WriteLine("The greatest value is {0}.", a);
        }
    }
}
