﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.NubersFrom1ToN
{
    class NubersFrom1ToN
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer N = ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
