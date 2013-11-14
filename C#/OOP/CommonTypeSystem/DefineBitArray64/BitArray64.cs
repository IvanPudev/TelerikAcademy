using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DefineBitArray64 
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong number;

        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public ulong Number
        {
            get { return this.number; }
            private set { this.number = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] bits = ConvertToBitsArray();
            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];
            }
        }

        private int[] ConvertToBitsArray()
        {
            int[] bits = new int[64];
            for (int i = 0; i < bits.Length; i++)
            {
                int bit = (int)((Number >> i) & 1);
                bits[63 - i] = bit; 
            }
            return bits;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BitArray64))
            {
                return false;
            }
            BitArray64 number = obj as BitArray64;
            if (ReferenceEquals(number, null))
            {
                return false;
            }
            if (ReferenceEquals(this, number))
            {
                return true;
            }
            return this.Number == number.Number;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int this[int index]
        {
            get 
            {
                if (index < 0 || index > 63)
                {
                    throw new System.IndexOutOfRangeException();
                }

                int[] bits = this.ConvertToBitsArray();
                return bits[index];
            }
        }

        public static bool operator ==(BitArray64 number1, BitArray64 number2)
        {
            return number1.Equals(number2);
        }

        public static bool operator !=(BitArray64 number1, BitArray64 number2)
        {
            return !(number1 == number2);
        }
    }
}
