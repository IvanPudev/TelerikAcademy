using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


//Write a program that reverses the words in given sentence.

namespace ReverseWordsInSentence
{
    class ReverseWordsInSentence
    {
        static void Main(string[] args)
        {
            string text = "C# is not C++, not PHP and not Delphi!";
            StringBuilder result = new StringBuilder();
            char[] splitters = { ' ', '.', ',', ';', ':', '!', '?', '-' };
            string[] words = text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            string[] tempArray = Regex.Split(text, "[A-Za-z0-9#+_]");
            
            List<string> symbols = new List<string>();
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] != String.Empty)
                {
                    symbols.Add(tempArray[i]);
                }
            }
            
            for (int i = 0; i < symbols.Count(); i++)
            {
                    if (i <= words.Length)
                    {
                        result.Append(words[i]);
                    }
                    result.Append(symbols[i]);
            }
            
            Console.WriteLine(result);
        }
    }
}
