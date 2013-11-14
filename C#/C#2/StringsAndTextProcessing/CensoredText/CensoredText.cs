using System;
using System.Linq;

namespace CensoredText
{
    class CensoredText
    {
        static void Main(string[] args)
        {
            string text = "Microsoft announced its next generation PHP compiler today."+
                          " It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            text = text.Replace("PHP", "***");
            text = text.Replace("Microsoft", "*********");
            text = text.Replace("CLR", "***");
            Console.WriteLine(text);
        }
    }
}
