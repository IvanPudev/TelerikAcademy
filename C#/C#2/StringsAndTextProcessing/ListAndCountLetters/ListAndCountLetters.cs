using System;
using System.Collections.Generic;
using System.Linq;

//Write a program that reads a string from the console and prints all different
//letters in the string along with information how many times each letter is found.

namespace ListAndCountLetters
{
    class ListAndCountLetters
    {
        static void Main(string[] args)
        {
            string text = "Write a program that reads a string from the console and prints all different " + 
                          "letters in the string along with information how many times each letter is found.";
            int counter = 1;
            List<string> chars = new List<string>();

            text = text.ToLower();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i]>='a' && text[i] <= 'z' )
                {
                    chars.Add(text[i].ToString());
                }
            }

            chars.Sort();
            
            for (int i = 0; i < chars.Count - 1; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    counter++;
                }
                else
                {
                    Console.WriteLine("{0}:{1}", counter, chars[i]);
                    counter = 1;
                }
            }
        }
    }
}
