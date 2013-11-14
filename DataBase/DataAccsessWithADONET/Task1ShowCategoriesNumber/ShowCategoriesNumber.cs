using System;
using System.Data.SqlClient;
using System.Linq;

//Write a program that retrieves from the Northwind sample database 
//in MS SQL Server the number of  rows in the Categories table.

namespace Task1ShowCategoriesNumber
{
    internal class ShowCategoriesNumber
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");

            connection.Open();
            using (connection)
            {
                SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Categories", connection);
                int categoriesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("The number of rows in categories is: {0}", categoriesCount);
            }
        }
    }
}
