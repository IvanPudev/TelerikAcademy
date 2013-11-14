using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;
namespace Task1
{
    class Program
    {
        static OrderedSet<string> combinations = new OrderedSet<string>();
        static Dictionary<int, Frame> frames = new Dictionary<int, Frame>();
        static int framesCount;
        static void Main(string[] args)
        {
            framesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < framesCount; i++)
            {
                string frameStr = Console.ReadLine();
                string[] frameParams = frameStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int frameFirst = int.Parse(frameParams[0]);
                int frameSecond = int.Parse(frameParams[1]);
                frames.Add(i, new Frame(frameFirst, frameSecond, i));
            }
            FindSolution(new Frame[framesCount], 0, new HashSet<int>());
            StringBuilder output = new StringBuilder();
            output.AppendLine(combinations.Count.ToString());
            foreach (var combination in combinations)
            {
                output.AppendLine(combination);
            }
            Console.Write(output);
        }
        static void FindSolution(Frame[] currentCombination, int i, HashSet<int> usedIds)
        {
            if (i == framesCount)
            {
                SaveCombination(currentCombination);
                return;
            }
            else
            {
                for (int j = 0; j < framesCount; j++)
                {
                    if (!usedIds.Contains(j))
                    {
                        currentCombination[i] = frames[j];
                        usedIds.Add(j);
                        FindSolution(currentCombination, i + 1, usedIds);
                        currentCombination[i] = frames[j].ReversedFrame();
                        FindSolution(currentCombination, i + 1, usedIds);
                        usedIds.Remove(j);
                    }
                }
            }
        }
        private static void SaveCombination(Frame[] currentCombination)
        {
            StringBuilder combination = new StringBuilder();
            for (int i = 0; i < framesCount - 1; i++)
            {
                combination.Append(currentCombination[i].ToString());
                combination.Append(" | ");
            }
            combination.Append(currentCombination[framesCount - 1].ToString());
            combinations.Add(combination.ToString());
        }
    }
    class Frame
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Id { get; set; }
        public Frame(int first, int second, int id)
        {
            this.First = first;
            this.Second = second;
            this.Id = id;
        }
        public Frame ReversedFrame()
        {
            return new Frame(this.Second, this.First, this.Id);
        }
        public override string ToString()
        {
            return "(" + this.First + ", " + this.Second + ")";
        }
    }
}


