//Write a program that reads a sequence of integers (List<int>)
//ending with an empty line and sorts them in an increasing order.

using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskThreeSortSequenceIncreasingUsingList
{
    class SortSequenceIncreasingUsingList
    {
        /// <summary>
        /// Method that gets string data, converts it to integer and stores data in list
        /// </summary>
        /// <returns>Returns list of int</returns>
        private static List<int> InputSequence()
        {
            List<int> readSequence = new List<int>();

            while (true)
            {
                string readNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(readNumber))
                {
                    break;
                }
                else
                {
                    readSequence.Add(int.Parse(readNumber));
                }
            }

            return readSequence;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter integer numbers of the sequence: ");
            List<int> sequence = InputSequence();

            sequence.Sort();

            Console.Write("The increasingly ordered sequence is: ");
            foreach (var element in sequence)
            {
                Console.Write("{0} ", element);
            }
        }
    }
}
