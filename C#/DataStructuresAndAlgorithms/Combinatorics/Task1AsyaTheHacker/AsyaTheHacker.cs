using System;
using System.Linq;
using System.Numerics;

namespace Task1AsyaTheHacker
{
    class AsyaTheHacker
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] password = input.ToCharArray();
            int length = password.Length;
            int count = 0;

            for (int i = 0; i < length; i++)
            {
                if (password[i] == '*')
                {
                    count++;
                }
                
            }

            if (count != 0)
            {
                BigInteger result = (BigInteger)Math.Pow(2, count);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("1");
            }
        }
    }
}
