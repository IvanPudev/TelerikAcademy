using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableExtension
{
    class TestExecutable
    {
        static void Main()
        {
            IEnumerable<string> array = new string[] { "a", "b", "c" };
            Console.WriteLine(array.MyAverage()); 
        }
    }
}
