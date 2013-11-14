using System;
using System.Linq;

namespace ColorRabbits
{
    class ColorRabbitsSolution
    {
        static void Main(string[] args)
        {
            int rabbitsAsked = int.Parse(Console.ReadLine());
            int[] answersNumber = new int[rabbitsAsked];

            for (int i = 0; i < rabbitsAsked; i++)
            {
                answersNumber[i]= int.Parse(Console.ReadLine());
            }

            int[] answers = new int[1000002];

            for (int i = 0; i < answersNumber.Length; i++)
            {
                answers[answersNumber[i] + 1]++;
            }

            int result = 0;

            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == 0)
                {
                    continue;
                }
                if (answers[i] <= 1)
                {
                    result += i;
                }
                else
                {
                    result += (int)Math.Ceiling((double)answers[i] / i) * i;
                }
            }

            Console.WriteLine(result);
        }
    }
}
