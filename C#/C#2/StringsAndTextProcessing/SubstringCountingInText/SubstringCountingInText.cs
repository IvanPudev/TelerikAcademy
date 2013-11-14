using System;
using System.Linq;

//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).

namespace SubstringCountingInText
{
    class SubstringCountingInText
    {
        static void Main(string[] args)
        {
            string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            int counter = 0;
            int index = -1;
            string searchedWord = "in";

            while (true)
            {
                index = text.IndexOf(searchedWord, index + 1, StringComparison.CurrentCultureIgnoreCase);
                if (index == -1)
                {
                    break;
                }
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}
