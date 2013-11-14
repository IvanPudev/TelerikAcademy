using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CheckBitValue
{
    class CheckBitValue
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter position: ");
            int position = int.Parse(Console.ReadLine());
            int checker = 1;
            int mask = checker << position;
            Console.WriteLine((number & mask) != 0 ? true : false);
        }
    }
}
