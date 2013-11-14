using System;
using System.Linq;

namespace Task2LevensteinDistance
{
    public class LevenshteinDistance
    {
        const decimal CostReplace = 1M;
        const decimal CostDelete = 0.9M;
        const decimal CostInsert = 0.8M;

        public static decimal Compute(string firstWord, string secondWord)
        {
            int firstWordLength = firstWord.Length;
            int secondWordLength = secondWord.Length;
            decimal[,] calculatingMatrix = new decimal[firstWordLength + 1, secondWordLength + 1];

            if (firstWordLength == 0)
            {
                return secondWordLength;
            }

            if (secondWordLength == 0)
            {
                return firstWordLength;
            }

            for (int row = 0; row <= firstWordLength; row++)
            {
                calculatingMatrix[row, 0] = row* CostDelete;
            }

            for (int col = 0; col <= secondWordLength; col++)
            {
                calculatingMatrix[0, col] = col * CostInsert;
            }

            for (int row = 1; row <= firstWordLength; row++)
            {
                for (int col = 1; col <= secondWordLength; col++)
                {
                    decimal cost = (secondWord[col - 1] == firstWord[row - 1]) ? 0 : CostReplace;

                    decimal delete = calculatingMatrix[row - 1, col] + CostDelete;
                    decimal insert = calculatingMatrix[row, col - 1] + CostInsert;
                    decimal replace = calculatingMatrix[row - 1, col - 1] + cost;

                    calculatingMatrix[row, col] = Math.Min(Math.Min(delete, insert),replace);
                }
            }
            return calculatingMatrix[firstWordLength, secondWordLength];
        }
    }

}
