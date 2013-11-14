using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3Employees
{
    class Problem3Employees
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] position = input.Split('-');
                position[i] = position[i].Trim();
                int jobCode = int.Parse(position[1]);
                if (!dict.ContainsKey(input))
                {
                    dict.Add(input, jobCode);
                }
                dict.Values.OrderByDescending(x => x);
            }

            int m = int.Parse(Console.ReadLine());
            Dictionary<string, string> names = new Dictionary<string, string>();
            for (int i = 0; i < m; i++)
            {
                string input = Console.ReadLine();
                string[] name = input.Split('-');
                name[i] = name[i].Trim();
                names.Add(name[0], name[1]);
            }
            
        }
    }
}
