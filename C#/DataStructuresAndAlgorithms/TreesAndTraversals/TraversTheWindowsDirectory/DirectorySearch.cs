using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Task2TraverseTheWindowsDirectory
{
    class DirectorySearch
    {
        private static readonly List<string> files = new List<string>();

        private static void TraverseDirectory(string dirPath, string fileExtention)
        {
            string[] currentDirectories = new string[0];

            try
            {
                string[] currentFiles = Directory.GetFiles(dirPath, fileExtention);
                files.AddRange(currentFiles);

                currentDirectories = Directory.GetDirectories(dirPath);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Directory {0}: Access denied by the system.", dirPath);
                return;
            }

            foreach (var directory in currentDirectories)
            {
                TraverseDirectory(directory, fileExtention);
            }
        }

        static void Main(string[] args)
        {
            string directoryPath = @"C:\Windows";
            string fileExtention = "*.exe";

            TraverseDirectory(directoryPath, fileExtention);

            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
