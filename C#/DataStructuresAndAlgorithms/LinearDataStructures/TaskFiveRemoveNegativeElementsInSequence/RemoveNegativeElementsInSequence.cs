//Write a program that removes from given sequence all negative numbers.

using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskFiveRemoveNegativeElementsInSequence
{
    class RemoveNegativeElementsInSequence
    {
        /// <summary>
        /// Method that gets string data, converts it to integer and stores data in LinkedList
        /// </summary>
        /// <returns>Returns LinkedList of int</returns>
        private static LinkedList<int> InputSequence()
        {
            LinkedList<int> readSequence = new LinkedList<int>();

            while (true)
            {
                string readNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(readNumber))
                {
                    break;
                }
                else
                {
                    readSequence.AddLast(int.Parse(readNumber));
                }
            }

            return readSequence;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter integer numbers of the sequence: ");
            LinkedList<int> sequence = InputSequence();
            
            var element = sequence.First;

            while (element != null)
            {
                var next = element.Next;

                if (element.Value < 0)
                    sequence.Remove(element);

                element = next;
            }

            Console.WriteLine("The list after removing all negative elements:");
            Console.Write("{0} ", sequence);
        }
    }
}
