using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.LastDiggitReturnMethod
{
    class LastDiggitReturnMethod
    {
        static string LastDiggit(int numberCheck)
        {
            string[] diggitsName = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            int lastDiggitIndex = numberCheck % 10;
            return diggitsName[lastDiggitIndex];
        }
        static void Main(string[] args)
        {
            Console.Write("Enter integer Number: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("The name of the last diggit in english is: {0}", LastDiggit(n));
        }
    }
}
