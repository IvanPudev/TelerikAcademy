using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.BinaryDigitsCount
{
    class BinaryDigitsCount
    {
        static void Main(string[] args)
        {
            byte b = byte.Parse(Console.ReadLine());
            short n = short.Parse(Console.ReadLine());
            uint[] a = new uint[n];
            int counter1 = 0;
            int counter2 = 0;
            for (int i = 0; i < n; i++)
            {
                uint number = uint.Parse(Console.ReadLine());
                if (b == 1)
                {
                    for (int bitNum = 63; bitNum >= 0; bitNum--)
                    {
                        uint bitValue = (a[i] >> bitNum) & 1;
                        if (bitValue == 1)
                        {
                            counter1++;
                        }
                    }
                    Console.WriteLine(counter1);
                }
                else if (b == 0)
                {
                    for (int bitNum = 63; bitNum >= 0; bitNum--)
                    {
                        uint bitValue = (a[i] >> bitNum) & 0;
                        counter2++;
                    }
                    Console.WriteLine(counter2);
                }
            }
        }
    }
}
