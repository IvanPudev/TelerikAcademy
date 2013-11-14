using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.ConvertHexidecimalToDecimal
{
    class ConvertHexidecimalToDecimal
    {
        static long ConvertHexToDec(string numberToConvert)
        {
            long result = 0;
            
            numberToConvert = numberToConvert.ToUpper();
            for (int i = numberToConvert.Length - 1, pow = 1; i >= 0; i--, pow *= 16)
            {
                if (char.IsDigit(numberToConvert, i))
                {
                    result = result + (numberToConvert[i] - '0') * pow;
                }
                else
                {
                    result = result + (numberToConvert[i] - 'A' + 10) * pow;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            string number = "FF1";
            Console.WriteLine(ConvertHexToDec(number));
        }
    }
}
