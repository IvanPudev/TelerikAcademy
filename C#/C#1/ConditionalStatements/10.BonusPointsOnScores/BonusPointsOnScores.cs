using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.BonusPointsOnScores
{
    class BonusPointsOnScores
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Score between interval [1;9]: ");
            string score = Console.ReadLine();

            switch (score)
            {
                case "1":
                case "2":
                case "3":
                    Console.WriteLine("Your bonus points are {0} x 10. Your score is: {1}", score, int.Parse(score) * 10);
                    break;
                case "4":
                case "5":
                case "6":
                    Console.WriteLine("Your bonus points are {0} x 100. Your score is: {1}", score, int.Parse(score) * 100);
                    break;
                case "7":
                case "8":
                case "9":
                    Console.WriteLine("Your bonus points are {0} x 1000. Your score is: {1}", score, int.Parse(score) * 1000);
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
        }
    }
}
