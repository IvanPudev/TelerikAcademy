using System;
using System.Linq;
using System.Text;

//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. 

namespace SubstringsToUpperCase
{
    class SubstringsToUpperCase
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            string start = "<upcase>";
            string end = "</upcase>";
            int startTag = -1, endTag = -1;
            int index = 0;

            while (true)
            {
                startTag = text.IndexOf(start, startTag + 1);
                endTag = text.IndexOf(end, endTag + 1);

                if (startTag == -1)
                {
                    break;
                }

                result.Append(text.Substring(index, startTag - index));
                index = endTag + 9;
                result.Append(text.Substring(startTag + 8, (endTag - startTag - 8)).ToUpper());
            }
            result.Append(text.Substring(text.LastIndexOf(end) + 9));

            Console.WriteLine(result);
        }
    }
}
