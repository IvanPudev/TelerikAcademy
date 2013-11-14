using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskMessageInABottle
{
    class Program
    {
        static readonly List<KeyValuePair<char, string>> cyphers = new List<KeyValuePair<char, string>>();
        static string message;

        static void Main(string[] args)
        {
            message = Console.ReadLine();
            string cypher = Console.ReadLine();

            char key = char.MinValue;
            StringBuilder value = new StringBuilder();

            for (int i = 0; i < cypher.Length; i++)
            {
                if ('A' <= cypher[i] && cypher[i] <= 'Z')
                {
                    if (key != char.MinValue)
                    {
                        cyphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                        value.Clear();
                    }
                    
                    key = cypher[i];
                }
                else
                {
                    value.Append(cypher[i]);
                }
            }

            if (key != char.MinValue)
            {
                cyphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                value.Clear();
            }

            Solve(0, new StringBuilder());

            Console.WriteLine(solutions.Count);

            solutions.Sort();

            foreach (var item in solutions)
            {
                Console.WriteLine(item);
            }
        }

        static readonly List<string> solutions = new List<string>();

        static void Solve(int secretMessageIndex, StringBuilder sb)
        {
            if (secretMessageIndex==message.Length)
            {
                solutions.Add(sb.ToString());
                return;
            }

            foreach (var cypher in cyphers)
            {
                if (message.Substring(secretMessageIndex).StartsWith(cypher.Value))
                {
                    sb.Append(cypher.Key);
                    Solve(secretMessageIndex + cypher.Value.Length, sb);
                    sb.Length--;
                }
            }
        }
    }
}
