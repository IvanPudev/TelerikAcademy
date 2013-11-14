namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int collectionLength = collection.Count;

            if (collectionLength > 1)
            {
                List<T> less = new List<T>();
                List<T> bigger = new List<T>();
                int pivotIndex = collection.Count / 2;
                List<T> pivot = new List<T> { collection[pivotIndex] };

                for (int i = 0; i < collectionLength; i++)
                {
                    if (i != pivotIndex)
                    {
                        if (collection[i].CompareTo(pivot[0]) < 0)
                        {
                            less.Add(collection[i]);
                        }
                        else
                        {
                            bigger.Add(collection[i]);
                        }
                    }
                }

                this.Sort(less);
                this.Sort(bigger);

                List<T> concatenatedList = less.Concat(pivot).Concat(bigger).ToList();

                for (int index = 0; index < collectionLength; index++)
                {
                    collection[index] = concatenatedList[index];
                }
            }
        }
    }
}
