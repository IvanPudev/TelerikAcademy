using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTablesAndSetsPracticalTask
{
    class Program
    {


        Dictionary<char,HashSet<string>> wordsByCharDict = new Dictionary<char,HashSet<string>>();

        static void InitDict()
        {
            for (char a = 'a'; a <= 'z'; a++)
            {
                wordByCharDict[a] = new HashSet[a];  
            }
        }

        static void ReadWords()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine().ToLower();
                StringBuilder word = new StringBuilder();

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] >= 'a' && input[j] <= 'z')
                    {
                        word.Append(input[j]);
                    }
                    else if (input[j] >= 'A' && input[j] <= 'Z')
                    {
                        word.Append((char)(input[j] - 'A' + 'a'));
                    }
                    else if (word.Length > 0)
                    {
                        InitDict(word.ToString());
                        word.Clear();
                    }

                    if (word.Length > 0)
                    {
                        InitDict(word.ToString());
                        word.Clear();
                    }
                }
            }
        }

        static void Main()
        {

        }
    }
}
