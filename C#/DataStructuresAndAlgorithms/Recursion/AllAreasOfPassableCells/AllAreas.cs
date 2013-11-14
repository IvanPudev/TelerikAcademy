using System;

namespace LargestArea
{
    public class LargestAreaInMatrix
    {
        static char[,] matrix = new char[8, 8]
        {
            {'0','1','0','1','0','1','0','0'},
            {'0','0','0','1','0','1','1','0'},
            {'0','0','0','1','0','1','1','0'},
            {'0','0','0','1','0','1','0','0'},
            {'0','1','0','1','0','1','1','0'},
            {'0','0','0','1','0','1','0','0'},
            {'1','1','1','1','0','1','1','1'},
            {'0','0','0','0','0','0','0','0'},
        };

        static void FindPaths(int row, int col, char label)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == label || matrix[row, col] == '1')
            {
                return;
            }

            matrix[row, col] = label;

            FindPaths(row + 1, col, label);
            FindPaths(row - 1, col, label);
            FindPaths(row, col + 1, label);
            FindPaths(row, col - 1, label);
        }

        static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            char label = 'A';

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == '0')
                    {
                        FindPaths(i, j, label);
                        label++;
                    }
                }
            }

            PrintMatrix();
        }
    }
}
