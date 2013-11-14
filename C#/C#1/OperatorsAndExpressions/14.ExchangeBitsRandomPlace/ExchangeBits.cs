using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.ExchangeBitsRandomPlace
{
    class ExchangeBits
    {
        static void Main(string[] args)
        {
            uint number = 1111111111;
            int b = 2,
                ot = 0,
                iot = 5;
            for (int i = 0; i < b; i++)
            {
                uint firstBit = number >> (i + ot) & (uint)1;
                uint secondBit = number >> (i + iot) & (uint)1;

                if (firstBit != secondBit)
                {
                    if (firstBit == 1)
                    {
                        number ^= (uint)1 << (i + ot);
                        number |= (uint)1 << (i + iot);
                    }
                    else
                    {
                        number |= (uint)1 << (i + ot);
                        number ^= (uint)1 << (i + iot);
                    }
                }
            }
            Console.WriteLine(number);
        }
    }
}
