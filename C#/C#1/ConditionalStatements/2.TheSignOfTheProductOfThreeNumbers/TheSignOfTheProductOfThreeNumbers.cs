using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.TheSignOfTheProductOfThreeNumbers
{
    class TheSignOfTheProductOfThreeNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first real number: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter first real number: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter first real number: ");
            double c = double.Parse(Console.ReadLine());

            if ((a < 0 && b < 0) || (a > 0 && b > 0))
            {
                if (c > 0)
                {
                    Console.WriteLine("The product of the three numbers is positive (+).");
                }
                else
                {
                    Console.WriteLine("The product of the three numbers is negative (-).");
                }
            }
            else if (c < 0)
            {
                Console.WriteLine("The product of the three numbers is positive (+).");
            }
            else
            {
                Console.WriteLine("The product of the three numbers is negative (-).");
            }     
            
        }
    }
}
