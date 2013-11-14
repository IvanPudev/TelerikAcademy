using System;
using System.Linq;

namespace DefineBitArray64
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 number1 = new BitArray64(12345);
            BitArray64 number2 = new BitArray64(123456);
            int index = 30;
            Console.WriteLine("number1 in bits: ");
            foreach (var bit in number1)
            {
                Console.Write(bit);
            }
            Console.WriteLine();
            Console.WriteLine("Bit at position {0} is {1}", index, number1[index]);
            Console.WriteLine("Hash code of {0}: {1}", number1.Number, number1.GetHashCode());

            Console.WriteLine("number1 == number2 -> {0}", number1 == number2);
            Console.WriteLine("number1 != number2 -> {0}", number1 != number2);
            Console.WriteLine("number1 equals number2 -> {0}", number1.Equals(number2));
        }
    }
}
