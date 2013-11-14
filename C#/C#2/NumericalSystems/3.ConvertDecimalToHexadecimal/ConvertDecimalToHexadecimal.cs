using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.ConvertDecimalToHexadecimal
{
    class ConvertDecimalToHexadecimal
    {
        static string ConvertDecToHex(int numberToConvert)
        {
            StringBuilder result = new StringBuilder();
            while (numberToConvert != 0)
            {
                int reminder = numberToConvert % 16;
                
                if (reminder > 9)
                {
                    switch (reminder) 
                    {
                        case 10: result.Insert(0, 'A');
                            break;
                        case 11: result.Insert(0, 'B');
                            break;
                        case 12: result.Insert(0, 'C');
                            break;
                        case 13: result.Insert(0, 'D');
                            break;
                        case 14: result.Insert(0, 'E');
                            break;
                        case 15: result.Insert(0, 'F');
                            break;
                    }
                }
                else
                {
                    result.Insert(0, reminder);
                }
                numberToConvert /= 16; 
            }
            return result.ToString();
        }
        static void Main(string[] args)
        {
            Console.Write("Enter integer you want to convert in hexidecimal: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("The hexidecimal value of {0} is: {1}", number, ConvertDecToHex(number));
        }
    }
}
