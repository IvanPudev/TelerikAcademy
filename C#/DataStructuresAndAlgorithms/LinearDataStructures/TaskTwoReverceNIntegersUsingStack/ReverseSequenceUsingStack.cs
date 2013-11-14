//Write a program that reads N integers from the console and
//reverses them using a stack. Use the Stack<int> class.

using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskTwoReverceNIntegersUsingStack
{
    class ReverseSequenceUsingStack
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number N for sequence length: ");
            int n = int.Parse(Console.ReadLine());

            Stack<int> secuence = new Stack<int>();

            for (int i = 1; i <= n; i++)
            {
                Console.Write("Enter {0} element: ", i);
                int element = int.Parse(Console.ReadLine());
                secuence.Push(element);
            }

            Console.WriteLine();
            Console.Write("The reversed sequence is: ");

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", secuence.Pop());
            }

            Console.WriteLine();
        }
    }
}
