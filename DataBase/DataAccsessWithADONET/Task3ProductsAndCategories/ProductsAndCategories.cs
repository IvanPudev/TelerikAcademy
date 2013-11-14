using System;
using System.Data.SqlClient;
using System.Linq;

//Write a program that retrieves from the Northwind database all 
//product categories and the names of the products in each category. 
//Can you do this with a single SQL query (with table join)?

namespace Task3ProductsAndCategories
{
    internal class ProductsAndCategories
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");

            connection.Open();
            using (connection)
            {
                SqlCommand cmdSql = new SqlCommand("SELECT " +
	                                                   "c.CategoryName, " +
	                                                   "p.ProductName " +
                                                   "FROM Products p " +
                                                   "JOIN Categories c " +
	                                                   "ON p.CategoryID = c.CategoryID " +
                                                   "GROUP BY    c.CategoryName, " +
			                                                   "p.ProductName", connection);

                SqlDataReader reader = cmdSql.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine("{0} - {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}
