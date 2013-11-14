using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.CopyRightTriangle
{
    class CopyrightTriangle
    {
        static void Main(string[] args)
        {
            char c = '\u00A9';
            Console.WriteLine(c);
            Console.WriteLine("{0} {0}", c);
            Console.WriteLine("{0} {0} {0}", c);
            Console.WriteLine("{0} {0}", c);
            Console.WriteLine(c);
        }
    }
}
