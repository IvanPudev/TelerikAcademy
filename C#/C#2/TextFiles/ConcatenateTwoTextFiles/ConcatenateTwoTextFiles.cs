using System;
using System.Linq;
using System.IO;

namespace ConcatenateTwoTextFiles
{
    class ConcatenateTwoTextFiles
    {
        static void Main(string[] args)
        {
            StreamReader readFirstFile = new StreamReader("..\\..\\Text1.txt");
            StreamReader readSecondFile = new StreamReader("..\\..\\Text2.txt");
            StreamWriter writeFile = new StreamWriter("..\\..\\ConcatenatedFiles.txt");

            string firstFileContent = readFirstFile.ReadToEnd();
            string secondFileContent = readSecondFile.ReadToEnd();

            using (writeFile) 
            {
                writeFile.Write(firstFileContent);
                writeFile.Write(secondFileContent);
            }
        }
    }
}
