using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.HelloWorld
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            string world = "World";
            object sentence = hello + " " + world; // concatenating the both
            string castSentence = (string)sentence;
            Console.WriteLine(sentence);
            Console.WriteLine(castSentence);
        }
    }
}
