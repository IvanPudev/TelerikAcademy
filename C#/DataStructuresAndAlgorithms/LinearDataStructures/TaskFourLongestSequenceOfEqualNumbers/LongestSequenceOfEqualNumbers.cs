//Write a method that finds the longest subsequence of equal numbers
//in given List<int> and returns the result as new List<int>.
//Write a program to test whether the method works correctly.

using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskFourLongestSequenceOfEqualNumbers
{
    class LongestSequenceOfEqualNumbers
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

            int subsequenceLenthCounter = 0;
            int subsequenceMaxLenth = 0;
            int mostRepeatedElementValue = 0;

            for (int i = 0; i < sequence.Count - 1; i++)
            {
                if (sequence[i] == sequence[i+1])
                {
                    subsequenceLenthCounter += 1;
                }
                else
                {
                    subsequenceLenthCounter = 1;
                }

                if (subsequenceLenthCounter > subsequenceMaxLenth)
                {
                    subsequenceMaxLenth = subsequenceLenthCounter;
                    mostRepeatedElementValue = sequence[i];
                }
            }

            List<int> maxSequence = new List<int>(subsequenceMaxLenth);

            for (int i = 0; i < subsequenceMaxLenth; i++)
            {
                maxSequence.Add(mostRepeatedElementValue);
            }

            foreach (int element in maxSequence)
            {
                Console.Write("{0} ", element);
            }
        }
    }
}
