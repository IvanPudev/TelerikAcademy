using System;
using System.Linq;
using System.IO;

namespace InsertLineNumbers
{
    class InsertLineNumbers
    {
        static void Main(string[] args)
        {
            StreamReader fileReader = new StreamReader("..\\..\\InsertLineNumbers.cs");
            StreamWriter fileWriter = new StreamWriter("..\\..\\NumberedLinesFile.txt");

            int number = 1;
            string line;
            using (fileReader)
            {
                using (fileWriter)
                {
                    while ((line = fileReader.ReadLine()) != null)
                    {
                        fileWriter.WriteLine("{0} {1}", number, line);
                        number++;
                    }
                }
            }
        }
    }
}