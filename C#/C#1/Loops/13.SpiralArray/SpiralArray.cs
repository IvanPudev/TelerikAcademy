using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.SpiralArray
{
    class SpiralArray
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number N [1;20]: ");
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            int direction = 1;
            int x = 0;
            int y = 0;
            int[,] array = new int[n,n];

            if (1 <= n && n <= 20)
            {
                while (counter <= n * n)
                {
                    array[x, y] = counter;
                    switch (direction)
                    {
                        case 1:
                            if (x + 1 < n && array[x + 1, y] == 0)
                            {
                                x++;
                            }
                            else
                            {
                                y++;
                                direction = 2;
                            }
                            break;
                        case 2:
                            if (y + 1 < n && array[x, y + 1] == 0)
                            {
                                y++;
                            }
                            else
                            {
                                x--;
                                direction = 3;
                            }
                            break;
                        case 3:
                            if (x > 0 && array[x - 1, y] == 0)
                            {
                                x--;
                            }
                            else
                            {
                                y--;
                                direction = 4;
                            }
                            break;
                        case 4:
                            if (y > 0 && array[x, y - 1] == 0)
                            {
                                y--;
                            }
                            else
                            {
                                x++;
                                direction = 1;
                            }
                            break;
                    }
                    counter++;
                }
                for (int cols = 0; cols < n; cols++)
                {
                    for (int rows = 0; rows < n; rows++)
                    {
                        if (n < 10)
                        {
                            Console.Write(array[rows, cols].ToString().PadLeft(3, ' '));
                        }
                        else
                        {
                            Console.Write(array[rows, cols].ToString().PadLeft(4, ' '));
                        }
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

    }
}
