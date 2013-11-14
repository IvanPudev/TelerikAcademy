using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

//Write a program that retrieves the images for all categories in the 
//Northwind database and stores them as JPG files in the file system.

namespace Task5RetrieveImages
{
    internal class RetrieveImages
    {
        private static readonly SqlConnection connection =
           new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
        private const string FileLocation = @"..\";
        private const string FileExtention = @".jpg";

        static void Main(string[] args)
        {
            using (connection)
            {
                RetrieveImage();
            }
        }

        private static void RetrieveImage()
        {
            connection.Open();
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT Picture, CategoryID FROM Categories", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    byte[] image;
                    int categoryID;

                    while (reader.Read())
                    {
                        image = (byte[])reader["Picture"];
                        categoryID = (int)reader["CategoryID"];

                        WriteFile(image, FileLocation + categoryID + FileExtention);
                    }
                }
            }
            
        }

        static void WriteFile(byte[] fileContent, string fileLocation)
        {
            FileStream stream = new FileStream(fileLocation, FileMode.Create);
            using (stream)
            {
                stream.Write(fileContent, 78, fileContent.Length - 78);
            }
        }
    }
}
