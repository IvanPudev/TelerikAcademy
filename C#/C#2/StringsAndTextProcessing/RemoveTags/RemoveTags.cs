using System;
using System.Linq;

//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. 

namespace RemoveTags
{
    class RemoveTags
    {
        static void Main(string[] args)
        {
            string text = "<html>"+
                           "<head><title>News</title></head>"+
                           "<body><p><a href=\"http://academy.telerik.com\">Telerik"+
                           "Academy</a>aims to provide free real-world practical"+
                           "training for young people who want to turn into"+
                           "skillful .NET software engineers.</p></body>"+
                           "</html>";

            int startIndex = text.IndexOf('<');
            int endIndex = text.IndexOf('>');
            string result;

            while (startIndex >= 0)
            {
                text = text.Remove(startIndex, endIndex - startIndex + 1);
                startIndex = text.IndexOf('<');
                endIndex = text.IndexOf('>');
            }

            result = text.Trim();
            Console.WriteLine(result);
        }
    }
}
