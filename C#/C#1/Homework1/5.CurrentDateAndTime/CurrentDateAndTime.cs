using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDateAndTime
{
    class CurrentDateAndTime
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("The current date and time are: {0}", DateTime.Now);
        }
    }
}