namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int collectionLength = collection.Count;

            if (collectionLength > 1)
            {
                List<T> leftSide = new List<T>();
                List<T> rightSide = new List<T>();

                for (int index = 0; index < collectionLength / 2; index++)
                {
                    leftSide.Add(collection[index]);
                }

                for (int index = collectionLength / 2; index < collectionLength; index++)
                {
                    rightSide.Add(collection[index]);
                }

                this.Sort(leftSide);
                this.Sort(rightSide);

                for (int index = collectionLength - 1; index >= 0; index--)
                {
                    if (leftSide.Count == 0)
                    {
                        collection[index] = rightSide.Last();
                        rightSide.Remove(rightSide.Last());
                    }
                    else if (rightSide.Count == 0)
                    {
                        collection[index] = leftSide.Last();
                        leftSide.Remove(leftSide.Last());
                    }
                    else if (leftSide.Last().CompareTo(rightSide.Last()) > 0)
                    {
                        collection[index] = leftSide.Last();
                        leftSide.Remove(leftSide.Last());
                    }
                    else
                    {
                        collection[index] = rightSide.Last();
                        rightSide.Remove(rightSide.Last());
                    }
                }
            }
        }
    }
}
