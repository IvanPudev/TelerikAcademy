using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.EditingVariablesDependingOnType
{
    class EditingVariablesDependingOnType
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the type of variable you want:\n" + "Integer = 1\n" + "double = 2\n" + "string = 3");
            int variable = int.Parse(Console.ReadLine());

            switch (variable)
            {
                case 1:
                    Console.Write("Enter your integer variable: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.WriteLine("The edited integer is {0}.", a + 1);
                    break;
                case 2:
                    Console.Write("Enter your integer variable: ");
                    double b = int.Parse(Console.ReadLine());
                    Console.WriteLine("The edited integer is {0}.", b + 1);
                    break;
                case 3:
                    Console.Write("Enter your integer variable: ");
                    string c = Console.ReadLine();
                    Console.WriteLine("The edited integer is {0}." + "*", c);
                    break;
                default:
                    Console.WriteLine("Invalid variable type.");
                    break;
            }
        }
    }
}
