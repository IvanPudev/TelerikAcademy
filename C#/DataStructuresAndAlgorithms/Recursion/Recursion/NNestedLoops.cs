using System;

namespace NNestedLoops
{
    class NNestedLoops
    {

        static void NestedLoops(int count, int max, string path)
        {
            if (count == max)
            {
                Console.WriteLine(path);
                return;
            }

            for (int i = 1; i <= max; i++)
            {
                NestedLoops(count + 1, max, path + " " + i);
            }
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            NestedLoops(0, N, "");
        }
    }
}
