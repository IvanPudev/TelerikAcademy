using System;
using System.Linq;
using System.Text;

//Write a program that reads a string from the console and 
//replaces all series of consecutive identical letters with a single one. 

namespace JustOneLetterIfRepeating
{
    class JustOneLetterIfRepeating
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            result.Append(str[0]);

            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] != result[result.Length -1])
                {
                    result.Append(str[i]);
                }
            }
            Console.WriteLine("The result is: {0}", result);
        }
    }
}
