using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1KnapsackProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Item item1 = new Item("Paint", 3, 5);
            Item item2 = new Item("Laptop", 2, 3);
            Item item3 = new Item("GSM", 1, 4);

            List<Item> items = new List<Item>();
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            int bagCapacity = 5;

            KnapSackProblem problem = new KnapSackProblem();

            int totalValueOfItems = 0;
            List<Item> itemsToBePacked = problem.FindItemsToPack(items, bagCapacity, out totalValueOfItems);

            foreach (var item in itemsToBePacked)
            {
                Console.WriteLine(item);
            }
        }
    }
}
