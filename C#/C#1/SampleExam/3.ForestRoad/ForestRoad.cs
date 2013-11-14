using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.ForestRoad
{
    class ForestRoad
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            for (int row = 0; row < n; row++)
            {
                int asterisks = 1;
                int dots = row;
                Console.Write(new string('.', dots));
                Console.Write(new string('*', asterisks));
                Console.Write(new string('.', (n-1) - dots));
                Console.WriteLine();
            }
            for (int row = n - 1; row > 0; row--)
            {
                int asterisks = 1;
                int dots = row;
                Console.Write(new string('.', dots - 1));
                Console.Write(new string('*', asterisks));
                Console.Write(new string('.',n - dots));
                Console.WriteLine();
            }
        }
    }
}
