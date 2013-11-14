using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskAcademyTasks
{
    class Program
    {
        static List<int> tasks = new List<int>();
        static int variety;
        static int maxIndex;

        static void Main(string[] args)
        {
            string tasksAsStringLine = Console.ReadLine();
            var tasksAsString = tasksAsStringLine.Split(new char[] { ',', ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var task in tasksAsString)
            {
                tasks.Add(int.Parse(task));
            }

            variety = int.Parse(Console.ReadLine());
            Console.WriteLine(SolveWithDP());

            //bestSolution = tasks.Count;

            //int currentMin = tasks[0];
            //int currentMax = tasks[0];
            //maxIndex = -1;

            //for (int i = 0; i < tasks.Count; i++)
            //{
            //    currentMin = Math.Min(currentMin, tasks[i]);
            //    currentMax = Math.Max(currentMax, tasks[i]);

            //    if (currentMax - currentMin >= variety)
            //    {
            //        maxIndex = i;
            //        break;
            //    }
            //}

            //if (maxIndex == -1)
            //{
            //    Console.WriteLine(tasks.Count);
            //    return;
            //}

            //Solve(0, 1, tasks[0], tasks[0]);

            //Console.WriteLine(bestSolution);
        }

        static int SolveWithDP()
        {
            int minCount = tasks.Count;

            for (int i = 0; i < tasks.Count - 1; i++)
            {
                for (int j = i + 1; j < tasks.Count; j++)
                {
                    if (Math.Abs(tasks[i] - tasks[j]) >= variety)
                    {
                        int count = 0;
                        count += (i + 1) / 2;
                        count += (j - i + 1) / 2 + 1;
                        minCount = Math.Min(count, minCount);
                    }
                }
            }

            return minCount;
        }

        static int bestSolution;

        static void Solve(int currentIndex, int taskSolved, int currentMin, int currentMax)
        {
            if (currentMax - currentMin >= variety)
            {
                bestSolution = Math.Min(bestSolution, taskSolved);
                return;
            }

            if (currentIndex >= maxIndex)
            {
                return;
            }

            for (int i = 2; i >= 1; i--)
            {
                if (currentIndex + i < tasks.Count)
                {
                    Solve(currentIndex + i, taskSolved + 1,
                        Math.Min(currentMin, tasks[currentIndex + i]),
                        Math.Max(currentMax, tasks[currentIndex + i]));
                }

                if (bestSolution != tasks.Count)
                {
                    return;
                }
            }
        }
    }
}
