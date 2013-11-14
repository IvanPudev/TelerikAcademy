using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Print52CardsFromAStandartDeck
{
    class Print52CardsFromAStandartDeck
    {
        static void Main(string[] args)
        {
            string[] suits = { "clubs", "diamonds", "hearts", "spades" };
            string[] cards = { " A", " 2", " 3", " 4", " 5", " 6", " 7", " 8", " 9", "10", " J", " Q", " K" };

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < cards.Length; j++)
                {
                    Console.WriteLine("{0} of {1}",cards[j],suits[i]);
                }
            }
        }
    }
}
