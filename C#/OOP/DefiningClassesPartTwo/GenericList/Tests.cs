using System;
using System.Linq;

namespace GenericList
{
    class Tests
    {
        static void Main()
        {
            GenericList<int> list = new GenericList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
            Console.WriteLine(list);
            Console.WriteLine(list[1]);
            list.Add(5);
            Console.WriteLine(list);
            list.RemoveAt(1);
            Console.WriteLine(list);
            list.InsertAt(1, 1);
            Console.WriteLine(list);
            Console.WriteLine(list.FindByValue(3));
            list.Clear();
            Console.WriteLine(list);
        }
    }
}
