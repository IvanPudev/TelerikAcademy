using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MissCat2011
{
    class MissCat2011
    {
        static void Main(string[] args)
        {
            int[] catNum = new int[10];
            int index = 0;
            int count = 0;
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {                
                int catScore = int.Parse(Console.ReadLine());
                catNum[catScore - 1]++;                
            }

            for (int i = 0; i < 10; i++)
            {
                if (count < catNum[i])
                {
                    count = catNum[i];
                    index = i + 1;
                }
            }
            Console.WriteLine(index);
            
        }
    }
}
