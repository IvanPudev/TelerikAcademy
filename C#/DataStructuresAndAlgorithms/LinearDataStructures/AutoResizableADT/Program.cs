//Implement the ADT stack as auto-resizable array.
//Resize the capacity on demand
//(when no space is available to add / insert a new element).

using System;
using System.Linq;

namespace AutoResizableADT
{
    class ImplementationOfStack
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(5);

            int[] stackToArray = stack.ToArray();
            for (int i = 0; i < stackToArray.Length; i++)
            {
                Console.Write(stackToArray[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Contains(0));
            stack.Clear();
            Console.WriteLine(stack.Count);
        }
    }
}
