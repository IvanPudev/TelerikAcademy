using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ExchangeBits345to242526
{
    class ExchangeBits345to242526
    {
        static void Main(string[] args)
        {
            uint number = 111111111;
            for (int i = 0; i < 3; i++)
            {
                uint firstBit = number >> (i + 3) & (uint)1;
                uint secondBit = number >> (i + 24) & (uint)1;

                if (firstBit != secondBit)
                {
                    if (firstBit == 1)
                    {
                        number ^= (uint)1 << (i + 3);
                        number |= (uint)1 << (i + 24);
                    }
                    else
                    {
                        number |= (uint)1 << (i + 3);
                        number ^= (uint)1 << (i + 24);
                    }
                }
            }
            Console.WriteLine(number);
        }
    }
}
