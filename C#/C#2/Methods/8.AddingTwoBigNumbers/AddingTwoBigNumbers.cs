using System;
using System.Collections.Generic;

namespace _8.AddingTwoBigNumbers
{
    class AddingTwoBigNumbers
    {
        static List<byte> AddNumbers(string number1, string number2)  //In God We Trust
        {
            int length = Math.Min(number1.Length, number2.Length);
            byte[] numberArray1 = new byte[number1.Length];
            byte[] numberArray2 = new byte[number2.Length];
            byte reminder = 0;
            Array.Reverse(numberArray1);
            Array.Reverse(numberArray2);
            //Parsing the numbers
            for (int i = 0; i < number1.Length; i++)                      
            {
                numberArray1[i] = (byte)(number1[i] - '0');
            }
            for (int i = 0; i < number2.Length; i++)
            {
                numberArray2[i] = (byte)(number2[i] - '0');
            }
            //Calculatng the length of the result
            byte[] longerArray = (numberArray1.Length > numberArray2.Length) ? numberArray1 : numberArray2;
            List<byte> result = new List<byte>(longerArray.Length + 1);
            //Calcilating result
            for (int i = 0; i < length; i++)
            {
                byte sum = (byte)(numberArray1[i] + numberArray2[i] + reminder);
                if (sum > 9)
                {
                    result.Add((byte)(sum % 10));
                    reminder = 1;
                }
                else
                {
                    result.Add(sum);
                    reminder = 0;
                }
            }

            if (numberArray1 != numberArray2)
            {
                for (int i = length; i < longerArray.Length; i++)
                {
                    byte sum = (byte)(longerArray[i] + reminder);
                    if (sum > 9)
                    {
                        result.Add((byte)(sum % 10));
                        reminder = 1;
                    }
                    else
                    {
                        result.Add(sum);
                        reminder = 0;
                    }
                }
            }

            if (reminder != 0)
            {
                result.Add(1);
            }

            result.Reverse();
            return result;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            string firstNumber = Console.ReadLine();
            Console.Write("Enter second number: ");
            string secondNumber = Console.ReadLine();

            List<byte> result = AddNumbers(firstNumber, secondNumber);
            foreach (var digit in result)
            {
                Console.Write(digit);
            }
            Console.WriteLine();
        }
    }
}
