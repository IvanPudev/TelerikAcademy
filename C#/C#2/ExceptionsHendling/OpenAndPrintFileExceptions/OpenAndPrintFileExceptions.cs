using System;

namespace OpenAndPrintFileExceptions
{
    class OpenAndPrintFileExceptions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Filename you want to open and print to the Console \n(file must be with its full path):");
            try
            {
                string filePath = Console.ReadLine();
                string fileContent = System.IO.File.ReadAllText(filePath);
                Console.WriteLine(fileContent);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Not a valid file path. Check your spelling.");
            }
            catch (System.IO.PathTooLongException)
            {
                Console.WriteLine("The path and file name you entered is too long. Must be up to 260 symbols.");
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                Console.WriteLine("Invalid path entry.");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Oops. There was a problem occurred while opening file.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You cannot open or print this file. \n(file is read-only, file format is not supported, no admin rights).");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Not a valid format of path.");
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("You dont have permition to open this file.");
            }
        }
    }
}
