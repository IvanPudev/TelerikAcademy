using System;
using System.Collections.Generic;
using System.Linq;

//Write a program that reads a string from the console and lists all 
//different words in the string along with information how many times each word is found.


namespace ListAndCountWords
{
    class ListAndCountWords
    {
        static void Main(string[] args)
        {
            string text = "Write a program that reads a string from the console and lists all different words in " +
                          "the string along with information how many times each word is found. " +
                          "Write a program that  lists all different words in the string along " +
                          "with information how many times each word is found. Write a program " +
                          "that reads a string from the console and lists all different words how many times each word is found.";

            text.ToLower();

            char[] splitters = { ' ', '.', ',', ';', ':', '!', '?', '-', '@', '#', '$', '"', '/', '\\', '|', '~', '^', '&', '*', '+' };
            string[] splittedText = text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            
            Dictionary<string, int> dict = new Dictionary<string,int>();

            foreach (var word in splittedText)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word] = dict[word] + 1;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }

            foreach (var key in dict)
            {
                Console.WriteLine("{0} times: {1}", key.Value, key.Key);
            }
        }
    }
}
