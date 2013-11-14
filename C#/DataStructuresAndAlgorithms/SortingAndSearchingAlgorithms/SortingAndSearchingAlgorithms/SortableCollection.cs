namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (item.CompareTo(items[i]) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int indexMin = 0;
            int indexMax = this.items.Count;

            while (indexMax >= indexMin)
            {
                int idexAverage =(indexMin + indexMax) / 2;

                if (items[idexAverage].CompareTo(item) < 0)
                {
                    indexMin = idexAverage + 1;
                }
                else if (items[idexAverage].CompareTo(item) > 0)
                {
                    indexMax = idexAverage - 1;
                }
                else
                {
                    return true;
                }
            }
            
            return false;
        }

        public void Shuffle()
        {
            Random randomizer = new Random();

            int lestLenght = this.items.Count;

            for (int index = 0; index < lestLenght; index++)
            {
                int randomIndex = randomizer.Next(index, lestLenght - 1);

                T swaper = this.items[index];
                this.items[index] = this.items[randomIndex];
                this.items[randomIndex] = swaper;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
