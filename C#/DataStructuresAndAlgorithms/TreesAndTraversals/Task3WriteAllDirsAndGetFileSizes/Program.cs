//Define classes File { string name, int size } and 
//Folder{ string name, File[] files, Folder[] childFolders } 
//and using them build a tree keeping all files and folders on 
//the hard drive starting from C:\WINDOWS. Implement a method that 
//calculates the sum of the file sizes in given subtree of the tree 
//and test it accordingly. Use recursive DFS traversal.

using System;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Task3WriteAllDirsAndGetFileSizes
{
    public class Program
    {
        static Folder root = null;

        static void BuildFolderSystem(string path, Folder parent)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            Folder currentFolder = new Folder(dir.Name);

            if (root == null)
            {
                root = currentFolder;
            }
            else
            {
                parent.AddSubFolder(currentFolder);
            }

            var directories = dir.GetDirectories();

            foreach (var directory in directories)
            {
                try
                {
                    BuildFolderSystem(directory.FullName, currentFolder);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            var files = dir.GetFiles();

            foreach (var file in files)
            {
                FileInfo currentFile = new FileInfo(file.FullName);

                currentFolder.AddFile(new File(currentFile.Name, currentFile.Length));
            }
        }

        static Folder foundFolder = null;

        static void FindFolder(Folder currentFolder, string name)
        {
            if (currentFolder.Name == name)
            {
                foundFolder = currentFolder;
            }
            else
            {
                foreach (var folder in currentFolder.ChildFolders)
                {
                    FindFolder(folder, name);
                }
            }
        }

        static BigInteger folderSizeSum = 0;
        static long numberOfFiles = 0;
        static long numberOfFolders = 0;

        static void FindSum(Folder folder)
        {
            foreach (var file in folder.Files)
            {
                folderSizeSum += file.Size;
                numberOfFiles++;
            }

            foreach (var fold in folder.ChildFolders)
            {
                numberOfFolders++;
                FindSum(fold);
            }
        }

        public static void Main()
        {
            //change to whatever path you want
            string path = @"C:\Intel";
            BuildFolderSystem(path, null);

            //calculate size of subtree
            string folderName = "MyFolder";
            FindFolder(root, folderName);
            FindSum(foundFolder);
            Console.WriteLine("Folder \"{0}\" information", folderName);
            Console.WriteLine("Size in folder: " + (folderSizeSum / (1024 * 1024)) + " MB" + " (" + folderSizeSum + " B)");
            Console.WriteLine("Number of files: " + numberOfFiles);
            Console.WriteLine("Number of folders: " + numberOfFolders);
        }
    }
}
