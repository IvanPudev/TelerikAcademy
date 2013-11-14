using System;
using System.Linq;

//Write a program to check if in a given expression the brackets are put correctly.

namespace BracketsCheck
{
    class BracketsCheck
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            bool result = true;
            int checker = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == '(')
                {
                    checker++;
                }
                if (str[i] == ')')
                {
                    checker--;
                }
                if (checker == -1)
                {
                    result = false;
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
