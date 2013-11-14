using System;
using System.Linq;
using System.Text;

//Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
//Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
//Implement methods for adding element, accessing element by index, removing element by index,
//inserting element at given position, clearing the list, finding element by its value and ToString().
//Check all input parameters to avoid accessing elements at invalid positions.
//Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
//Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>.
//You may need to add a generic constraints for the type T.

namespace GenericList
{
    public class GenericList<T>
    {
        #region Fields

        private const int ArrayLenth = 4;
        private T[] array;

        #endregion

        #region Constructors

        public GenericList()
            : this(ArrayLenth)
        {
        }

        public GenericList(int capacity)
        {
            this.Capacity = capacity;
            this.array = new T[capacity];
        }

        #endregion

        #region Properties

        public int Capacity { get; private set; }
        public int Count { get; private set; }
        public T this[int index]
        {
            get { return this.array[index]; }
            set { this.array[index] = value; }
        }

        #endregion

        #region Methods

        public void Add(T element)
        {
            AutoGrowth();
            this.array[Count] = element;
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("Element out of range.");
            }
            for (int i = index; i < Count - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            this.array[Count - 1] = default(T);
            Count--;
        }

        public void InsertAt(int index, T element)
        {
            AutoGrowth();
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("Element out of range.");
            }
            for (int i = Count; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }
            Count++;
            this.array[index] = element;
        }

        public void Clear()
        {
            this.array = new T[this.array.Length];
            Count = 0;
        }

        public int FindByValue(T value)
        {
            int index = -1;
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private void AutoGrowth()
        {
            if (Count == this.array.Length)
            {
                T[] doubledArray = new T[this.array.Length * 2];
                for (int i = 0; i < Count; i++)
                {
                    doubledArray[i] = this.array[i];
                }
                this.array = doubledArray;
            }
        }

        public T Min()
        {
            var minValue = array[0] as IComparable<T>;
            if (minValue == null)
            {
                throw new NullReferenceException("Cannot be null.");
            }
            for (int i = 1; i < Count; i++)
            {
                if (minValue.CompareTo(array[i]) >= 0)
                {
                    minValue = array[i] as IComparable<T>;
                }
            }
            return (T)minValue;
        }

        public T Max()
        {
            var maxValue = array[0] as IComparable<T>;
            if (maxValue == null)
            {
                throw new NullReferenceException("Cannot be null.");
            }
            for (int i = 1; i < Count; i++)
            {
                if (maxValue.CompareTo(array[i]) <= 0)
                {
                    maxValue = array[i] as IComparable<T>;
                }
            }
            return (T)maxValue;
        }

        public override string ToString()
        {
            StringBuilder arrayToString = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                arrayToString.AppendFormat("{0} ", this.array[i]);
            }
            return arrayToString.ToString();
        }

        #endregion
    }
}