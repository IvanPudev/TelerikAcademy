using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task4HashTableImplement
{
    public class MyHashSet<T> : IEnumerable<T>
    {
        #region Fields
        private MyHashTable<T, T> container;
        #endregion

        #region Properties
        public int Count
        {
            get { return this.container.Count; }
            private set { }
        }
        #endregion

        #region Public Methods
        public MyHashSet(params T[] values)
        {
            this.container = new MyHashTable<T, T>();

            if (values != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    this.container.Add(values[i], values[i]);
                }
            }
        }

        public void Add(T value)
        {
            this.container.Add(value, value);
        }

        public void Remove(T value)
        {
            this.container.Remove(value);
        }

        public T Find(T value)
        {
            T lookedValue = container.Find(value);

            return lookedValue;
        }

        public void Clear()
        {
            this.container = new MyHashTable<T, T>();
        }

        public void Unite(MyHashSet<T> otherSet)
        {
            foreach (var item in otherSet)
            {
                if (!this.container.Contains(new KeyValuePair<T, T>(item, item)))
                {
                    this.container.Add(item, item);
                }
            }
        }

        public void Intersect(MyHashSet<T> otherSet)
        {
            MyHashTable<T, T> otherTable = new MyHashTable<T, T>();
            foreach (var item in otherSet)
            {
                if (this.container.Contains(new KeyValuePair<T, T>(item, item)))
                {
                    otherTable.Add(item, item);
                }
            }

            this.container = otherTable;
        }
        #endregion

        #region Enumerator
        public IEnumerator<T> GetEnumerator()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
        #endregion
    }
}
