using System;
using System.Linq;
using System.IO;

namespace ReadAndPrintTextFile
{
    class ReadAndPrintTextFile
    {
        static void Main(string[] args)
        {
            StreamReader fileReader = new StreamReader("..\\..\\TextFile.txt");
            string fileContent = fileReader.ReadToEnd();
            Console.WriteLine(fileContent);
            fileReader.Close();
        }
    }
}
