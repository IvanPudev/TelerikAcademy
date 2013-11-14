using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.MembersOfSequence
{
    class MembersOfSequence
    {
        static void Main(string[] args)
        {
            for (int i = 2; i <= 11; i++)
            {
                if (i % 2 == 0)
                    Console.Write("{0}; ",i);
                else
                    Console.Write("{0}; ",i * (-1));
            }
            Console.WriteLine();
        }
    }
}
