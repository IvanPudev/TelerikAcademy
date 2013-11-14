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

        static int cellCounter = 0;
        static int maxCellCounter = 0;

        static void FindPaths(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 'X' || matrix[row, col] == '1')
            {
                return;
            }

            matrix[row, col] = 'X';
            cellCounter++;

            FindPaths(row + 1, col);
            FindPaths(row - 1, col);
            FindPaths(row, col + 1);
            FindPaths(row, col - 1);
        }

        static void Main()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 'X' || matrix[i,j] == '1')
                    {
                        cellCounter = 0;
                        FindPaths(i, j);

                        if (cellCounter > maxCellCounter)
                        {
                            maxCellCounter = cellCounter;
                        }
                    }
                }
            }

            Console.WriteLine(maxCellCounter);
        }
    }
}
