using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.NameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] digitsArray = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teensArray = { "ten", "eleven", "twelve", "thirtheen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tensArray = { "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            Console.Write("Enter integer number between the area [0; 999]: ");
            int number = int.Parse(Console.ReadLine());
            int hundreds = number / 100;
            int tens = (number % 100) / 10;
            int digits = (number % 100) % 10;

            if (number>=0 && number < 1000)
            {
                if (number <= 9)
                {
                    Console.WriteLine(digitsArray[number]); 
                }
                else if (number > 9 && number < 20)
                {
                    Console.WriteLine(teensArray[digits]);
                }
                else if (number >= 20 && number < 99) 
                {
                    if (digits != 0)
                    {
                        Console.WriteLine("{0} {1}", tensArray[tens-1], digitsArray[digits]);  
                    }
                    else
                    {
                        Console.WriteLine(tensArray[tens-1]);
                    }
                }
                else if (number >= 100)
                {
                    if (digits > 0 && tens < 1)
                    {
                        Console.WriteLine("{0} hundred and {1}", digitsArray[hundreds], digitsArray[digits]);
                    }
                    else if (digits > 0 && tens < 2)
                    {
                        Console.WriteLine("{0} hundred and {1}", digitsArray[hundreds], teensArray[digits]);
                    }
                    else if (tens >= 2)
                    {
                        if (digits != 0)
                        {
                            Console.WriteLine("{0} hundred and {1} {2}",digitsArray[hundreds], tensArray[tens-1], digitsArray[digits]);
                        }
                        else
                        {
                            Console.WriteLine("{0} hundred and {1}", digitsArray[hundreds], tensArray[tens-1]);
                        }
                    }
                    else if (tens == 0 && digits == 0)
                    {
                        Console.WriteLine("{0} hundred", digitsArray[hundreds]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
