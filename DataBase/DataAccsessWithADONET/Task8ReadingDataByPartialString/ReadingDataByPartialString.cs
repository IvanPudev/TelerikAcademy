using System;
using System.Data.SqlClient;
using System.Linq;

//Write a program that reads a string from the console and finds all products 
//that contain this string. Ensure you handle correctly characters like ', %, ", \ and _.

namespace Task8ReadingDataByPartialString
{
    class ReadingDataByPartialString
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter string to search for: ");
            string searchingString = Console.ReadLine();
            SqlConnection connection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT ProductName FROM Products WHERE CHARINDEX(@searchingString, ProductName) > 0", connection);
                command.Parameters.AddWithValue("@searchingString", searchingString);
                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine("Product's found: {0}", productName);
                    }
                }
            }
        }
    }
}
