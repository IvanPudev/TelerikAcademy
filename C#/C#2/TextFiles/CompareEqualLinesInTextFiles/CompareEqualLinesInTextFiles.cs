using System;
using System.Linq;
using System.IO;

namespace CompareEqualLinesInTextFiles
{
    class CompareEqualLinesInTextFiles
    {
        static void Main(string[] args)
        {
            int counter = 0;

            using (StreamReader firstFileReader = new StreamReader("..\\..\\Text1.txt"))
            {
                using (StreamReader secondFileReader = new StreamReader("..\\..\\Text2.txt"))
                {
                    string line1,line2;
                    while ((line1 = firstFileReader.ReadLine()) != null && (line2 = secondFileReader.ReadLine()) != null)
                    {
                        if (line1 == line2)
                        {
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine("The number of equal lines in the files is {0}", counter);
        }
    }
}