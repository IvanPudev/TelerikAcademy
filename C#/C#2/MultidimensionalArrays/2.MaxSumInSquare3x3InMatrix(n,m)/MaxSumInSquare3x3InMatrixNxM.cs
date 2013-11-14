using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MaxSumInSquare3x3InMatrix_n_m_
{
    class MaxSumInSquare3x3InMatrixNxM
    {
        static void Main(string[] args)
        {
            Console.Write("Enter column number N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter row number M: ");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[m, n];
            int sum = 0;
            int maxSum = int.MinValue;
            int matrixSumRow = 0;
            int matrixSumCol = 0;

            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("Enter [{0}, {1}] element: ", row + 1, col + 1);
                    matrix[row, col] = int.Parse(Console.ReadLine());
                }
            }

            for (int row = 0; row < m - 2; row++)
            {
                for (int col = 0; col < n - 2; col++)
                {
                    
                    for (int i = row; i < row + 3; i++)
                    {
                        for (int j = col; j < col + 3; j++)
                        {
                            sum += matrix[row, col];
                        }
                    }
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        matrixSumRow = row;
                        matrixSumCol = col;
                    }
                    sum = 0;
                }
            }

            Console.WriteLine("The matrix with the greatest Sum = {0}", maxSum);
            for (int row = matrixSumRow; row < matrixSumRow + 3; row++)
            {
                for (int col = matrixSumCol; col < matrixSumCol + 3; col++)
                {
                    Console.Write("{0, 4}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
