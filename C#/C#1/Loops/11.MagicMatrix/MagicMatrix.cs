using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.MagicMatrix
{
    class MagicMatrix
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer N [1<N<20]: ");
            int n = int.Parse(Console.ReadLine());

            if (1 < n && n < 20)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = i; j <= (i + (n - 1)); j++)
                    {
                        Console.Write(j);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
