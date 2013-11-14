using System;
using System.Collections.Generic;
using System.Linq;

//A dictionary is stored as a sequence of text lines containing words and their explanations. 
//Write a program that enters a word and translates it by using the dictionary. 

namespace Dictionary
{
    class Dictionary
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, string>()
            {
                { ".NET", "platform for applications from Microsoft" },
                { "CLR", "managed execution environment for .NET" },
                { "namespace", "hierarchical organization of classes" },
            };

            string input = Console.ReadLine();

            Console.WriteLine("{0} - {1}", input, dictionary[input]);
        }
    }
}
