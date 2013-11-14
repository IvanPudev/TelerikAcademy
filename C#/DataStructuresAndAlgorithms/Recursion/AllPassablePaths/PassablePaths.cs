using System;

namespace AllPassablePaths
{
    class PassablePaths
    {
        static char[,] matrix = new char[8, 8]
        {
            {'s','1','0','1','0','0','0','0'},
            {'0','1','0','1','0','1','1','0'},
            {'0','1','0','1','0','1','1','0'},
            {'0','1','0','1','0','1','1','0'},
            {'0','1','0','1','0','1','1','0'},
            {'0','0','0','0','0','0','0','0'},
            {'0','1','1','1','1','1','1','0'},
            {'0','0','0','0','0','0','0','e'},
        };

        static void FindPaths(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                Console.WriteLine("Path found!");
                return;
            }

            if (matrix[row, col] == 'X' || matrix[row, col] == '1')
            {
                return;
            }

            matrix[row, col] = 'X';

            FindPaths(row + 1, col);
            FindPaths(row - 1, col);
            FindPaths(row, col + 1);
            FindPaths(row, col - 1);

            matrix[row, col] = '0';
        }

        static void Main()
        {
            int startRow = 0;
            int startCol = 0;

            bool startFound = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 's')
                    {
                        startRow = i;
                        startCol = j;
                        startFound = true;
                        break;
                    }
                }

                if (startFound)
                {
                    break;
                }
            }

            FindPaths(startRow, startCol);
        }
    }
}
