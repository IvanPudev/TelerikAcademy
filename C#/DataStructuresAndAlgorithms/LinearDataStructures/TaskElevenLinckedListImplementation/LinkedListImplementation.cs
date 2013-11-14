//Implement the data structure linked list. 
//Define a class ListItem<T> that has two fields: value (of type T)
//and NextItem (of type ListItem<T>). Define additionally a class
//LinkedList<T> with a single field FirstElement (of type ListItem<T>).

using System;
using System.Linq;

namespace TaskElevenLinkedListImplementation
{
    class LinkedListImplementation
    {
        static void Main()
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();
            linkedList.AddFirst(5);
            linkedList.AddLast(50);
            linkedList.AddFirst(10);
            linkedList.AddFirst(20);
            linkedList.AddLast(3);
            linkedList.AddAfter(linkedList.FirstElement.NextItem.NextItem.NextItem, 1000);
            linkedList.AddBefore(linkedList.FirstElement.NextItem.NextItem.NextItem, 50000);
            linkedList.AddBefore(linkedList.FirstElement, 0);
            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            ListItem<int> next = linkedList.FirstElement;
            while (next != null)
            {
                Console.WriteLine(next.Value);
                next = next.NextItem;
            }

            Console.WriteLine(linkedList.Count);
        }
    }
}
