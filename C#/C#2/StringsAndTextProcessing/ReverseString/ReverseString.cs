using System;
using System.Linq;
using System.Text;

//Write a program that reads a string, reverses it and prints the result at the console.

namespace ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string str = "example";
            StringBuilder result = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                result.Append(str[i]); 
            }

            Console.WriteLine(result);
        }
    }
}
