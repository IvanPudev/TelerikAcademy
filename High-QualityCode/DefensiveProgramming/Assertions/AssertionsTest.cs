using System;
using System.Diagnostics;
using System.Linq;

namespace Assertions
{
    public class AssertionsTest
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null!");

            int len = arr.Length;
            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }

            for (int i = 0; i < len - 1; i++)
            {
                Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "The array is not sorted!");
            }
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null!");
            Debug.Assert(startIndex >= 0, "Start index must be positive!");
            Debug.Assert(endIndex >= 0, "End index must be positive!");
            Debug.Assert(endIndex <= arr.Length - 1, "End index must be smaller than the length of the array!");
            Debug.Assert(startIndex <= endIndex, "Start index must be smaller than or equal to end index!");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            for (int i = startIndex + 1; i < endIndex; i++)
            {
                Debug.Assert(arr[minElementIndex].CompareTo(arr[i]) <= 0, "The element" + arr[minElementIndex] + " is not the smallest!");
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null");
            Debug.Assert(value != null, "Searched value cannot be null!");

            for (int i = 0; i < arr.Length - 1; i++)
            {
                Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "The array is not sorted!");
            }

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(startIndex <= endIndex, "Start index must be smaller than or equal to end index!");
            Debug.Assert(startIndex >= 0, "Start index must be positive!");
            Debug.Assert(endIndex >= 0, "End index must be positive!");
            Debug.Assert(endIndex <= arr.Length - 1, "End index must be smaller than the length of the array!");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    startIndex = midIndex + 1;
                }
                else
                {
                    endIndex = midIndex - 1;
                }
            }

            return -1;
        }

        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            SelectionSort(new int[0]);
            SelectionSort(new int[1]);

            Console.WriteLine();
            Console.WriteLine(BinarySearch(arr, -100));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 21));
            Console.WriteLine(BinarySearch(arr, 9));
            Console.WriteLine(BinarySearch(arr, 100));
        }
    }
}
