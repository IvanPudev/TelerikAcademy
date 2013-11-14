using System;
using System.Linq;

namespace PrintTenRandomValues
{
    class PrintTenRandomValues
    {
        static Random randomGenerator = new Random();

        static void Main(string[] args)
        {
            int length = 10;
            for (int i = 0; i < length; i++)
            {
                int randomNumber = randomGenerator.Next(100, 201);
                Console.WriteLine(randomNumber);
            }
        }
    }
}
