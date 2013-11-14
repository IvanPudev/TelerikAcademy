using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.GetMaxMethod
{
    class GetMaxMethod
    {
        static int GetMax(int value1, int value2)
        {
            if (value1 > value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter First number: ");
            int number1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Second number: ");
            int number2 = int.Parse(Console.ReadLine());
            Console.Write("Enter Third number: ");
            int number3 = int.Parse(Console.ReadLine());
           
            Console.Write("The bigest number is: ", GetMax(GetMax(number1, number2), number3)); 
        }
    }
}
