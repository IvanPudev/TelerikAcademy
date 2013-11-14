using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.HelloName
{
    class HelloName
    {
        static void PrintHelloName()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, {0}!", name);
        }

        static void Main(string[] args)
        {
            PrintHelloName();
        }
    }
}
