//Write a program that reads from the console a sequence of positive integer numbers.
//The sequence ends when empty line is entered. Calculate and print the sum and average
//of the elements of the sequence. Keep the sequence in List<int>.

using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskOneSumAndAverageOfAPositiveSequence
{
    class SumAndAverageOfAPositiveSequence
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
            Console.WriteLine("Enter the positive integer elements of the sequence:");
            List<int> sequence = InputSequence();

            Console.WriteLine("The sum of the elements in the sequence is: {0}", sequence.Sum());
            Console.WriteLine("The average of the elements in the sequence is: {0}", sequence.Average());
        }
    }
}
