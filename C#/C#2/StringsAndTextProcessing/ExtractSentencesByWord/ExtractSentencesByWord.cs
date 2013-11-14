using System;
using System.Linq;

//Write a program that extracts from a given text all sentences containing given word.

namespace ExtractSentencesByWord
{
    class ExtractSentencesByWord
    {
        static void Main(string[] args)
        {
            string text = "We are living in a yellow submarine. We don't have anything else." + 
                          "Inside the submarine is very tight. So we are drinking all the day." +
                          " We will move out of it in 5 days.";
            string[] sentences = text.Split('.');
            string word = " in";
            
            foreach (var sentence in sentences)
            {
                if (sentence.IndexOf(word) != - 1)
                {
                    Console.WriteLine("{0}.", sentence);
                }
            }
        }
    }
}
