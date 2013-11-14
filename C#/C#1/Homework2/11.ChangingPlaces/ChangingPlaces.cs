using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ChangingPlaces
{
    class ChangingPlaces
    {
        static void Main(string[] args)
        {
            byte a = 5;
            byte b = 10;
            byte c = a;
            Console.WriteLine("Before changing the places the fyrst number is {0} and second is {1}", a, b);
            a = b;
            b = c;
            Console.WriteLine("After changing the places the fyrst number is {0} and second is {1}", a, b);
        }
    }
}
