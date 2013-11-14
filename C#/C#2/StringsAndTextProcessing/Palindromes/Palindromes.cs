using System;
using System.Linq;

//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

namespace Palindromes
{
    class Palindromes
    {
        static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            string text = "sos, los, creative; massom, abba mamam trapatam, sas";
            char[] splitters = { ' ', '.', ',', ';', ':', '!', '?', '-' };
            string[] wordsArray = text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in wordsArray)
            {
                if (IsPalindrome(word))
                {
                    Console.WriteLine(word);
                } 
            }
        }
    }
}
