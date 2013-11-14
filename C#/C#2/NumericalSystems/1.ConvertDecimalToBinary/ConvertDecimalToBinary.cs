using System;
using System.Text;

namespace _1.ConvertDecimalToBinary
{
    class ConvertDecimalToBinary
    {
        static string ConvertDecToBin(int numberToConvert)
        {
            StringBuilder result = new StringBuilder();

            while (numberToConvert != 0)
            {
                result.Insert(0, numberToConvert % 2);
                numberToConvert /= 2;
            }

            return result.ToString();
        }
        static void Main(string[] args)
        {
            int decNumber = 100;
            Console.WriteLine(ConvertDecToBin(decNumber));
        }
    }
}
