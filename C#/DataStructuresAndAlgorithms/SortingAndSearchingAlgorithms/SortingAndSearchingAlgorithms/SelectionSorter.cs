namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int listLength = collection.Count;

            for (int comparingIndex = 0;
                comparingIndex < listLength - 1; comparingIndex++)
            {
                int min = comparingIndex;

                for (int indexToCompareWith = comparingIndex + 1;
                    indexToCompareWith < listLength; indexToCompareWith++)
                {
                    if (collection[indexToCompareWith].CompareTo(collection[min]) < 0)
                    {
                        min = indexToCompareWith;
                    }
                }

                T swaper = collection[comparingIndex];
                collection[comparingIndex] = collection[min];
                collection[min] = swaper;
            }
        }
    }
}
