using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.PrimeNumbersTill10000000
{
    class PrimeNumbersTill10000000
    {
        static void Main(string[] args)
        {

            for (int i = 0; i <= 10000000; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime == true)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
