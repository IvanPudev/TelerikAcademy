using System;
using System.Collections.Generic;
using System.Linq;

//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

namespace SortWordsAlfabeticaly
{
    class SortWordsAlfabeticaly
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the words, separated by spaces:");
            string str = Console.ReadLine();
            string[] words = str.Split(' ');

            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word] += 1;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }

            dict.OrderByDescending(key=>key);

            foreach (var word in dict)
            {
                Console.Write(word.Key + " ");
            }
            Console.WriteLine();
        }
    }
}
