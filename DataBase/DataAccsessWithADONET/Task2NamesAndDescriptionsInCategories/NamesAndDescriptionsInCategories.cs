using System;
using System.Data.SqlClient;
using System.Linq;

//Write a program that retrieves the name and description 
//of all categories in the Northwind DB.

namespace Task2NamesAndDescriptionsInCategories
{
    internal class NamesAndDescriptionsInCategories
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");

            connection.Open();
            using (connection)
            {
                SqlCommand cmdSql = new SqlCommand("SELECT CategoryName, Description FROM Categories", connection);

                SqlDataReader reader = cmdSql.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0} - {1}", name, description);
                    }
                   
                }
            }
        }
    }
}
