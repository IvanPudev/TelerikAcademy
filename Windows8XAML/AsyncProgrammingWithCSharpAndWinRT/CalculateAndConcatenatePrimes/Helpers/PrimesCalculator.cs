using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateAndConcatenatePrimes.Helpers
{
    public static class PrimesCalculator
    {
        public static Task<List<int>> GetPrimesInRangeAsync(int rangeFirst, int rangeLast)
        {
            return Task.Run(() => GetPrimesInRange(rangeFirst, rangeLast));
        }

        public static Task<List<int>> ConcatenateNumberssAsync(List<int> primes)
        {
            return Task.Run(() => ConcatenateNumbers(primes));
        }

        public static Task<List<int>> GetComplexNumbersAsync(int rangeFirst, int rangeLast)
        {
            return Task.Run(() => GetComplexNumbersInRange(rangeFirst, rangeLast));
        }

        #region PrivateMethods

        private static List<int> GetPrimesInRange(int rangeFirst, int rangeLast)
        {
            List<int> primes = new List<int>();

            for (int number = rangeFirst; number < rangeLast; number++)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
            }

            return primes;
        }

        private static List<int> GetComplexNumbersInRange(int rangeFirst, int rangeLast)
        {
            List<int> complexes = new List<int>();

            for (int number = rangeFirst; number < rangeLast; number++)
            {
                if (!IsPrime(number))
                {
                    complexes.Add(number);
                }
            }

            return complexes;
        }

        private static List<int> ConcatenateNumbers(List<int> numbers)
        {
            var concatenatedNumbersList = new List<int>();

            foreach (int number in numbers)
            {
                string stringFirstNumber = number.ToString();
                char lastDigitOfFirstNumber = stringFirstNumber[stringFirstNumber.Length - 1];

                for (int index = 0; index < numbers.Count; index++)
                {
                    string stringNextNumber = numbers[index].ToString();
                    char firstDigitOfNextNumber = stringNextNumber[0];

                    if (lastDigitOfFirstNumber == firstDigitOfNextNumber)
                    {
                        var concatenatedPrimes = int.Parse(stringFirstNumber + stringNextNumber);
                        concatenatedNumbersList.Add(concatenatedPrimes);
                    }
                }
            }

            return concatenatedNumbersList;
        }

        private static bool IsPrime(int number)
        {
            bool isPrime = true;
            for (int divider = 2; divider < number; divider++)
            {
                if (number % divider == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }

        #endregion
    }
}
