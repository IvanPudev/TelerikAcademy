using System;
using System.Linq;

//Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 

namespace ReplacingTags
{
    class ReplacingTags
    {
        static void Main(string[] args)
        {
            string text = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course."+
                          " Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

            text = text.Replace("<a href=\"", "[URL=");
            text = text.Replace("\">", "]");
            text = text.Replace("</a>", "[/URL]");
            Console.WriteLine(text);
        }
    }
}
