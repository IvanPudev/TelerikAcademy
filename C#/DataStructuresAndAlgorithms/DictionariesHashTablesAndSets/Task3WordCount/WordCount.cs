using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task3WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"../../text.txt");
            using (reader)
            {
                string text = reader.ReadToEnd();
                char[] separators = { ' ', '.', ',', '!', '–', '?', ';', ':', '@', '&', '/' };
                string[] words = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> dictionary = new Dictionary<string, int>();

                foreach (var element in words)
                {
                    int counter = 0;
                    if (dictionary.ContainsKey(element))
                    {
                        counter = dictionary[element];
                    }
                    dictionary[element] = counter + 1;
                }

                foreach (KeyValuePair<string, int> item in dictionary.OrderBy(key => key.Value))
                {
                    Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
                }
            }
        }
    }
}
