using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.PrintMatrixInFourWays
{
    class PrintMatrixInFourWays
    {
        private static void PrintMatrix(int n, int[,] matrix)
        {
            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    Console.Write("{0, 3}", matrix[col, row]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter integer n: ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int count = 1;
            int direction = 1;
            int x = 0;
            int y = 0;
            

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = count++;
                }
            }
            PrintMatrix(n, matrix);

            Console.WriteLine();
            count = 1;

            for (int row = 0; row < n; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < n; col++)
                    {
                        matrix[col, row] = count++;
                    }
                }
                else
                {
                    for (int col = (n - 1); col >= 0; col--)
                    {
                        matrix[col, row] = count++;
                    }
                }
            }
            PrintMatrix(n, matrix);

            Console.WriteLine();
            count = 1;

            for (int rol = 0; rol <= n - 1; rol++)
                for (int col = 0; col <= rol; col++)
                {
                    matrix[n - rol + col - 1, col] = count++;
                }
            for (int row = n - 2; row >= 0; row--)
                for (int col = row; col >= 0; col--)
                {
                    matrix[row - col, n - col - 1] = count++;
                }
            PrintMatrix(n, matrix);
        }

    }
}