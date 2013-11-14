using System;

namespace _2.ConvertBinaryToDecimal
{
    class ConvertBinaryToDecimal
    {
        static int ConvertBinToDec(string numberToConvert)
        {
            int result = 0;

            for (int i = numberToConvert.Length - 1, shiftBit = 0; i >= 0 ; i--, shiftBit++)
            {
                result += (numberToConvert[i] - '0') << shiftBit;
            }

            return result;
        }
        static void Main(string[] args)
        {
            string binNumber = "101";
            Console.WriteLine(ConvertBinToDec(binNumber));
        }
    }
}
