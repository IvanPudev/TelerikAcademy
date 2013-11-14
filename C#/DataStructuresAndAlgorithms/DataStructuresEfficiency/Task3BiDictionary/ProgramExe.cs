using System;
using System.Linq;

namespace Task3BiDictionary
{
    class ProgramExe
    {
        static void Main()
        {
            BiDictionary<string, string, string> dictionary = new BiDictionary<string, string, string>();
            dictionary.Add("Sofia", "man", "Ivo Ivanov");
            dictionary.Add("Sofia", "woman", "Maria Ivanova");
            dictionary.Add("Plovdiv", "man", "Peter Petrov");
            dictionary.Add("Plovdiv", "woman", "Lili Georgieva");

            var fromSofia = dictionary.FindByFistKey("Sofia");
            foreach (var item in fromSofia)
            {
                Console.WriteLine(item);
            }

            var manGender = dictionary.FindBySecondKey("man");
            foreach (var item in manGender)
            {
                Console.WriteLine(item);
            }

            var manFromPlovdiv = dictionary.FindByBothKeys("Plovdiv", "man");
            foreach (var item in manFromPlovdiv)
            {
                Console.WriteLine(item);
            }
        }
    }
}
