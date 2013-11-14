using System;
using System.Data.SqlClient;
using System.Linq;

//Write a method that adds a new product in the products 
//table in the Northwind database. Use a parameterized SQL command.

namespace Task4AddNewProduct
{
    internal class AddNewProduct
    {
        private static readonly SqlConnection connection = 
            new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");

        static void Main(string[] args)
        {
            connection.Open();
            using (connection)
            {
                InsertProduct("Green Tea", 1, 1, "10 boxes x 20 bags", 18, 40, 20, 10);
            }
        }

        static void InsertProduct(string productName, int supplierID, int categoryID, string quantityPerUnit,
            float unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Products " +
                "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, " +
                "UnitsInStock, UnitsOnOrder, ReorderLevel) " +
                "VALUES (@name, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, " +
                "@unitsInStock, @unitsOnOrder, @reorderLevel)", connection);

            cmd.Parameters.AddWithValue("@name", productName);
            cmd.Parameters.AddWithValue("@supplierID", supplierID);
            cmd.Parameters.AddWithValue("@categoryID", categoryID);
            cmd.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            cmd.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            cmd.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            cmd.ExecuteNonQuery();

        }
    }
}
