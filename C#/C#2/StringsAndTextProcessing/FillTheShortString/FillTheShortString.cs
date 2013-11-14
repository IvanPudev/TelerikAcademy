using System;
using System.Linq;
using System.Text;

//Write a program that reads from the console a string of maximum 20 characters. 
//If the length of the string is less than 20, the rest of the characters should be filled with '*'.
//Print the result string into the console.

namespace FillTheShortString
{
    class FillTheShortString
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string betleen 1 and 20 symbols: ");
            string inputString = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            result.Append(inputString);

            while (result.Length < 20)
            {
                result.Append("*");
            }
            Console.WriteLine(result);
        }
    }
}
