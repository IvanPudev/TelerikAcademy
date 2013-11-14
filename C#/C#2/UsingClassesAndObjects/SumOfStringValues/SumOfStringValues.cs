using System;
using System.Linq;

namespace SumOfStringValues
{
    class SumOfStringValues
    {
        static void Main(string[] args)
        {
            string str = "43 68 9 23 318";
            int sum = 0;
            int tempSum = 0;
            int pow = 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    tempSum = tempSum * pow + (str[i]- '0');
                    pow = 10;
                }
                else
                {
                    sum +=tempSum;
                    tempSum = 0;
                    pow = 1;
                }
            }
            sum += tempSum;
            Console.WriteLine(sum);
        }
    }
}
