using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.AlphabeticalIndexesOfLettersInWord
{
    class AlphabeticalIndexesOfLettersInWord
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the word, which indexes you want to know: ");
            string word = Console.ReadLine().ToLower();
            char[] arrayWord = word.ToCharArray();
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            foreach (var letter in arrayWord)
            {
                for (int index = 1 ; index <= alphabet.Length; index++)
                {
                    if (letter == alphabet[index - 1])
                    {
                        Console.WriteLine("The letter {0} is with index {1} in the alphabet.", letter, index);
                    } 
                }
            }
        }
    }
}
