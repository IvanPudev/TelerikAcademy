using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.CheckThe_ThirdSymbolEquals7
{
    class CheckTheThirdSymbolEquals7
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer number: ");
            int number = int.Parse(Console.ReadLine());
            int check = number/100;
            if (check % 10 == 7)
            {
                Console.WriteLine("The third right-to-left digit is 7.");
            }
            else
            {
                Console.WriteLine("The third right-to-left digit is not 7.");
            }
        }
    }
}
