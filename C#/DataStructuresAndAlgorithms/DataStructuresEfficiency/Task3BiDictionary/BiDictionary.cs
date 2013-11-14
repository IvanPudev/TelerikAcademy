using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3BiDictionary
{
    public class BiDictionary<T, K, L>
    {
        private readonly MyHashTable<T, List<L>> firstKeyTable;
        private readonly MyHashTable<K, List<L>> secondKeyTable;
        private readonly MyHashTable<string, List<L>> bothKeysTable;

        public BiDictionary()
        {
            this.firstKeyTable = new MyHashTable<T, List<L>>();
            this.secondKeyTable = new MyHashTable<K, List<L>>();
            this.bothKeysTable = new MyHashTable<string, List<L>>();
        }

        public void Add(T firstKey, K secondKey, L value)
        {
            if (this.firstKeyTable.Contain(firstKey))
            {
                this.firstKeyTable[firstKey].Add(value);
            }
            else
            {
                this.firstKeyTable.Add(firstKey, new List<L> { value });
            }

            if (this.secondKeyTable.Contain(secondKey))
            {
                this.secondKeyTable[secondKey].Add(value);
            }
            else
            {
                this.secondKeyTable.Add(secondKey, new List<L> { value });
            }

            if (this.bothKeysTable.Contain(firstKey.ToString() + secondKey.ToString()))
            {
                this.bothKeysTable[firstKey.ToString() + secondKey.ToString()].Add(value);
            }
            else
            {
                this.bothKeysTable.Add(firstKey.ToString() + secondKey.ToString(), new List<L> { value });
            }
        }

        public IEnumerable FindByFistKey(T key)
        {
            return this.firstKeyTable[key];
        }

        public IEnumerable FindBySecondKey(K key)
        {
            return this.secondKeyTable[key];
        }

        public IEnumerable FindByBothKeys(T firstKey, K secondKey)
        {
            return this.bothKeysTable[firstKey.ToString() + secondKey.ToString()];
        }
    }
}