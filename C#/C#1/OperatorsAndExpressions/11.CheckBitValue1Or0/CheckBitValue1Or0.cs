using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.CheckBitValue1Or0
{
    class CheckBitValue1Or0
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter position: ");
            int position = int.Parse(Console.ReadLine());
            int checker = 1;
            int mask = checker << position;
            Console.WriteLine((number & mask) != 0 ? 1 : 0);
        }
    }
}
