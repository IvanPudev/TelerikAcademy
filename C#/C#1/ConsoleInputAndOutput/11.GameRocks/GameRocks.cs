using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11.GameRocks
{
    struct Rock
    {
        public int x;
        public int y;
        public char c;
        public ConsoleColor color;
    }
    struct Dwarf
    {
        public int x, y;
        public string c;
        public ConsoleColor color;
    }
    class GameRocks
    {
        static void PrintPosition(int x, int y, string c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }
        static void PrintPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }
        static void Main(string[] args)
        {
            int score = 0;
            char[] randomRock = new char[] { '@', '*', '%', '$', '&', '.', ',','!' };
            ConsoleColor[] randomColor = new ConsoleColor[] { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Cyan, ConsoleColor.Magenta };
            Console.BufferHeight = Console.WindowHeight = 25;
            Console.BufferWidth = Console.WindowWidth = 50;
            Dwarf dwarf = new Dwarf();
            dwarf.x = 15;
            dwarf.y = Console.WindowHeight - 1;
            dwarf.c = "(O)";
            dwarf.color = ConsoleColor.White;
            Random randomGenerator = new Random();
            List<Rock> rocks = new List<Rock>();
            bool isGoing = true;
            while (isGoing)
            {
                Rock rock = new Rock();
                rock.x = randomGenerator.Next(0, Console.WindowWidth - 1);
                rock.y = 0;
                rock.c = randomRock[randomGenerator.Next(0, 8)];
                rock.color = randomColor[randomGenerator.Next(0, 5)];
                rocks.Add(rock);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (dwarf.x >= 1)
                        {
                            dwarf.x = dwarf.x - 1;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (dwarf.x <= 45)
                        {
                            dwarf.x = dwarf.x + 1;
                        }
                    }
                }

                for (int i = 0; i < rocks.Count; i++)
                {
                    Rock fallingRock = new Rock();
                    fallingRock.x = rocks[i].x;
                    fallingRock.y = rocks[i].y + 1;
                    fallingRock.c = rocks[i].c;
                    fallingRock.color = rocks[i].color;
                    if (fallingRock.y != Console.WindowHeight)
                    {
                        rocks[i] = fallingRock;
                    }
                    else
                    {
                        rocks.RemoveAt(i);
                        score++;
                    }
                }
                Console.Clear();
                PrintPosition(dwarf.x, dwarf.y, dwarf.c, dwarf.color);
                foreach (Rock r in rocks)
                {
                    PrintPosition(r.x, r.y, r.c, r.color);
                }
                Thread.Sleep(150);
                foreach (Rock hittingRock in rocks)
                {
                    if (hittingRock.y == (Console.WindowHeight - 1) && hittingRock.x >= dwarf.x && hittingRock.x <= (dwarf.x + 2))
                    {
                        isGoing = false;
                        Console.Clear();
                        PrintPosition(6, 7, "GAME OVER" + "   SCORE: " + score + "\n", ConsoleColor.Red);
                    }
                }
            }

        }
    }
}