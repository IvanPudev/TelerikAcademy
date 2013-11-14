using System;
using System.Linq;
using System.Text;

//Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. 

namespace StringToUnicodeCharLiterals
{
    class StringToUnicodeCharLiterals
    {
        static void Main(string[] args)
        {
            string text = "C#!";
            StringBuilder unicodeChars = new StringBuilder();
            foreach (var letter in text)
            {
                unicodeChars.AppendFormat("\\u{0:X4}", (int)letter);
            }
            Console.WriteLine(unicodeChars);
        }
    }
}