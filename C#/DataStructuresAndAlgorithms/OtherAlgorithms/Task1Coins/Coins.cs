using System;
using System.Collections.Generic;

namespace Task1Coins
{
    class Coins
    {
        static void Main()
        {
            int sum = int.Parse(Console.ReadLine());

            List<int> coins = new List<int>() { 1, 2, 5 };
            coins.Sort();
            coins.Reverse();
            int[] coinsCount = new int[coins.Count];

            for (int i = 0; i < coins.Count; i++)
            {
                coinsCount[i] = sum / coins[i];
                sum = sum % coins[i];
            }
            if (sum != 0)
            {
                Console.WriteLine("No coin combination can give this sum");
            }
            else
            {
                for (int i = 0; i < coins.Count; i++)
                {
                    Console.WriteLine("{0}x{1}coins", coinsCount[i], coins[i]);
                }
            }
        }
    }
}
