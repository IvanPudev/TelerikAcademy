using System;
using System.Collections.Generic;

namespace EightQueens
{
    class Queens
    {
        static char[,] chessBoard = new char[8, 8]
        {
            {'0','0','0','0','0','0','0','0'},
            {'0','0','0','0','0','0','0','0'},
            {'0','0','0','0','0','0','0','0'},
            {'0','0','0','0','0','0','0','0'},
            {'0','0','0','0','0','0','0','0'},
            {'0','0','0','0','0','0','0','0'},
            {'0','0','0','0','0','0','0','0'},
            {'0','0','0','0','0','0','0','0'},
        };

        static int count = 0;

        static void Solution(int row, int col)
        {
            if (row == 8 && col == 0)
            {
                count++;
                return;
            }

            for (int i = 0; i < 8; i++)
            {
                if (chessBoard[row, i] == '0')
                {
                    Fill(row, i);
                    Solution(row + 1, 0);
                    Remove(row, i);
                }
            }
        }

        static void Fill(int row, int col)
        {
            for (int i = 0; i < 8; i++)
            {
                chessBoard[row, i]++;
            }

            for (int i = 0; i < 8; i++)
            {
                chessBoard[i, col]++;
            }

            int currentRow = row;
            int currentCol = col;

            while (currentRow >= 0 && currentCol >= 0)
            {
                chessBoard[currentRow, currentCol]++;

                currentRow--;
                currentCol--;
            }

            currentRow = row;
            currentCol = col;

            while (currentRow >= 0 && currentCol < 8)
            {
                chessBoard[currentRow, currentCol]++;

                currentRow--;
                currentCol++;
            }

            currentRow = row;
            currentCol = col;

            while (currentRow < 8 && currentCol < 8)
            {
                chessBoard[currentRow, currentCol]++;

                currentRow++;
                currentCol++;
            }

            currentRow = row;
            currentCol = col;

            while (currentRow < 8 && currentCol >= 0)
            {
                chessBoard[currentRow, currentCol]++;

                currentRow++;
                currentCol--;
            }
        }

        static void Remove(int row, int col)
        {
            for (int i = 0; i < 8; i++)
            {
                chessBoard[row, i]--;
            }

            for (int i = 0; i < 8; i++)
            {
                chessBoard[i, col]--;
            }

            int currentRow = row;
            int currentCol = col;

            while (currentRow >= 0 && currentCol >= 0)
            {
                chessBoard[currentRow, currentCol]--;

                currentRow--;
                currentCol--;
            }

            currentRow = row;
            currentCol = col;

            while (currentRow >= 0 && currentCol < 8)
            {
                chessBoard[currentRow, currentCol]--;

                currentRow--;
                currentCol++;
            }

            currentRow = row;
            currentCol = col;

            while (currentRow < 8 && currentCol < 8)
            {
                chessBoard[currentRow, currentCol]--;

                currentRow++;
                currentCol++;
            }

            currentRow = row;
            currentCol = col;

            while (currentRow < 8 && currentCol >= 0)
            {
                chessBoard[currentRow, currentCol]--;

                currentRow++;
                currentCol--;
            }
        }

        static void Main()
        {
            Solution(0, 0);
            Console.WriteLine(count);
        }
    }
}