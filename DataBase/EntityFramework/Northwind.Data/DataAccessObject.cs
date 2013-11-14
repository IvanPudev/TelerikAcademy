using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Transactions;

namespace Northwind.Data
{
    public class DataAccessObject
    {
        //Using the Visual Studio Entity Framework designer 
        //create a DbContext for the Northwind database

        #region Task2
        //Create a DAO class with static methods which provide functionality
        //for inserting, modifying and deleting customers. Write a testing class.

        public static void InsertCustomer(string customerID, string companyName, string contactName = null, string contactTitle = null,
                                      string address = null, string city = null, string region = null, string postalCode = null,
                                      string country = null, string phone = null, string fax = null)
        {
            NorthwindEntities context = new NorthwindEntities();
            using (context)
            {
                Customer customer = new Customer
                {
                    CustomerID = customerID,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };

                context.Customers.Add(customer);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
                Console.WriteLine("Row inserted.");
            }
        }

        public static void ModifyCustomer(string customerID, string companyName = null, string contactName = null, string contactTitle = null,
                                      string address = null, string city = null, string region = null, string postalCode = null,
                                      string country = null, string phone = null, string fax = null)
        {
            NorthwindEntities context = new NorthwindEntities();
            using (context)
            {
                Customer updatingCustomer = context.Customers.First(x => x.CustomerID == customerID);

                updatingCustomer.CompanyName = companyName ?? updatingCustomer.CompanyName;
                updatingCustomer.ContactName = contactName ?? updatingCustomer.ContactName;
                updatingCustomer.ContactTitle = contactTitle ?? updatingCustomer.ContactTitle;
                updatingCustomer.Address = address ?? updatingCustomer.Address;
                updatingCustomer.City = city ?? updatingCustomer.City;
                updatingCustomer.Region = region ?? updatingCustomer.Region;
                updatingCustomer.PostalCode = postalCode ?? updatingCustomer.PostalCode;
                updatingCustomer.Country = country ?? updatingCustomer.Country;
                updatingCustomer.Phone = phone ?? updatingCustomer.Phone;
                updatingCustomer.Fax = fax ?? updatingCustomer.Fax;

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
                Console.WriteLine("Row updated.");
            }
        }

        public static void DeleteCustomer(string customerID)
        {
            NorthwindEntities context = new NorthwindEntities();
            using (context)
            {
                Customer customer = context.Customers.FirstOrDefault(x => x.CustomerID == customerID);
                context.Customers.Remove(customer);

                try
                {
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
                Console.WriteLine("Row deleted.");
            }
        }
        #endregion

        #region Task3
        //Write a method that finds all customers who have orders
        //made in 1997 and shipped to Canada.

        public static void CustomersWithShippedOrdersToCanada1997()
        {
            NorthwindEntities context = new NorthwindEntities();
            using (context)
            {
                var customers = context.Orders.Where(o => o.OrderDate.Value.Year == 1997 && 
                    o.ShipCountry == "Canada").Select(o => o.Customer.CompanyName).Distinct();

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }
        #endregion

        #region Task4
        //Implement previous by using native SQL query and executing it through the DbContext.

        public static void CustomersWithShippedOrdersToCanada1997SqlQuery()
        {
            NorthwindEntities context = new NorthwindEntities();
            using (context)
            {
                var customers = context.Database.SqlQuery<string>(@"SELECT c.CompanyName 
                                                                    FROM Customers c 
                                                                        JOIN Orders o 
                                                                            ON c.CustomerID = o.CustomerID 
                                                                    WHERE YEAR(o.OrderDate) = 1997 
                                                                            AND o.ShipCountry = 'Canada' 
                                                                    GROUP BY c.CompanyName");
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }
        #endregion

        #region Task5
        //Write a method that finds all the sales by specified region and period (start / end dates).

        public static void FindSalesByRegionAndPeriod(string region = null, 
            string startDate = null, string endDate = null)
        {
            NorthwindEntities context = new NorthwindEntities();
            using (context)
            {
                DateTime parsedStartDate = DateTime.Parse(startDate);
                DateTime parsedEndDate = DateTime.Parse(endDate);

                var customers = context.Orders.Where(o => (parsedStartDate < o.OrderDate  &&
                    o.OrderDate < parsedEndDate) ||
                    o.ShipCountry == region).GroupBy(o => o.ShipName);

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }
        #endregion

        #region Task6
        //Create a database called NorthwindTwin with the same structure as 
        //Northwind using the features from DbContext. Find for the API for schema generation in MSDN or in Google.

        public static void CloneDatabase()
        {
            IObjectContextAdapter context = new NorthwindEntities();
            string cloneDb = context.ObjectContext.CreateDatabaseScript();

            string createCloneDb = "CREATE DATABASE NorthwindTwin ON PRIMARY " +
                "(NAME = NorthwindTwin, " +
                "FILENAME = 'D:\\NorthwindTwin.mdf', " +
                "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = NorthwindTwinLog, " +
                "FILENAME = 'D:\\NorthwindTwin.ldf', " +
                "SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";

            SqlConnection createDbConnection = new SqlConnection("Server=.; Database=master; Integrated Security=true");

            createDbConnection.Open();
            using(createDbConnection)
            {
                SqlCommand createDB = new SqlCommand(createCloneDb, createDbConnection);
                createDB.ExecuteNonQuery();
            }

            SqlConnection cloneDbConnection = new SqlConnection("Server=.; Database=NorthwindTwin; Integrated Security=true");

            cloneDbConnection.Open();
            using (cloneDbConnection)
            {
                SqlCommand cloneDbcmd = new SqlCommand(cloneDb, cloneDbConnection);
                cloneDbcmd.ExecuteNonQuery();
                Console.WriteLine("DataBase cloned.");
            }
        }
        #endregion

        #region Task7
        //Try to open two different data contexts and perform concurrent changes
        //on the same records. What will happen at SaveChanges()? How to deal with it?

        public static void PerformConcurentChanges()
        {
            NorthwindEntities context = new NorthwindEntities();
            using (context)
            {
                NorthwindEntities secondConnection = new NorthwindEntities();
                using (secondConnection)
                {
                    var firstConnUse = context.Customers.Find("CHOPS");
                    firstConnUse.Region = "BN";

                    var secondConnUse = secondConnection.Customers.Find("CHOPS");
                    secondConnUse.Region = "Bern";

                    context.SaveChanges();
                    secondConnection.SaveChanges();
                }

                Console.WriteLine("Changes successfully made.");
            }
        }
        #endregion

        #region Task9
        //Create a method that places a new order in the Northwind database.
        //The order should contain several order items. Use transaction to ensure the data consistency.

        public static void AddNewOrder(string customerId, KeyValuePair<int,short>[] productDetails)
        {
            NorthwindEntities context = new NorthwindEntities();
            using (context)
            {
                using(TransactionScope transaction = new TransactionScope())
                {
                    Order newOrder = new Order();
                    newOrder.CustomerID = customerId;

                    foreach (var product in productDetails)
                    {
                        Order_Detail newDetails = new Order_Detail();
                        newDetails.ProductID = product.Key;
                        newDetails.Quantity = product.Value;
                        newOrder.Order_Details.Add(newDetails);
                    }

                    context.Orders.Add(newOrder);
                    context.SaveChanges();
                    transaction.Complete();
                }

                Console.WriteLine("Order added.");
            }
        }
        #endregion

        #region Task10
        //Create a stored procedures in the Northwind database for finding the total
        //incomes for given supplier name and period (start date, end date). Implement
        //a C# method that calls the stored procedure and returns the retuned record set.

        //Use this script to create the procedure in the SQL Database Northwind
        //CREATE PROCEDURE [dbo].[SupplierAndPeriodByIncome] @SupplierName nvarchar(30), @StartDate datetime, @EndDate datetime
        //AS
        //SELECT SUM(p.UnitPrice)
        //FROM Orders o JOIN [Order Details] od ON o.OrderId = od.OrderId
        //JOIN Products p ON od.ProductId = p.ProductId
        //JOIN Suppliers s ON s.SupplierId = p.SupplierId 
        //WHERE s.ContactName = @SupplierName AND o.ShippedDate BETWEEN @StartDate AND @EndDate

        public static void TotalIncome(string contactName)
        {
            NorthwindEntities context = new NorthwindEntities();
            using(context)
            {
                var result = context.SupplierAndPeriodByIncome(contactName,
                    new DateTime(1800, 01, 01), new DateTime(2012, 12, 31)).ToList();

                Console.WriteLine("Expenses: {0}", result[0]);
            }
        }
        #endregion
    }
}
