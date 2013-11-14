using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SumSequence
{
    class SumSequence
    {
        static void Main(string[] args)
        {
            decimal sumNew = 1m;
            decimal sumOld = 0m;
            int divider = 2;
            int minus = 1;
            const decimal accurasy = 0.001m;
            do
            {
                sumOld = sumNew;
                sumNew = sumOld + minus * ((decimal)1 / divider);
                minus = minus * (-1);
                divider++;
            }
            while (Math.Abs(sumNew - sumOld) >= accurasy);
            Console.WriteLine(sumNew);
        }
    }
}
