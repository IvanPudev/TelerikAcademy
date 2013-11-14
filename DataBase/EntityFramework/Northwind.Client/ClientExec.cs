using System;
using System.Linq;
using Northwind.Data;
using System.Collections.Generic;

namespace Northwind.Client
{
    internal class ClientExec
    {
        static void Main(string[] args)
        {
            /**************************************/
            /*                                    */
            /* TO USE METHOD JUST UNCOMMENT IT :) */
            /*                                    */
            /**************************************/

            //Task 2
            //DataAccessObject.InsertCustomer("92", "Peshev");

            //Task 3
            //DataAccessObject.ModifyCustomer("92", "Peshev", "Modified");

            //Task 4
            //DataAccessObject.DeleteCustomer("92");

            //Task 5
            //DataAccessObject.CustomersWithShippedOrdersToCanada1997();

            //Task 6
            //DataAccessObject.CustomersWithShippedOrdersToCanada1997SqlQuery();

            //Task 7
            //DataAccessObject.CloneDatabase();

            //Task 8
            //DataAccessObject.PerformConcurentChanges();

            //Task 9
            //KeyValuePair<int, short>[] orderDetails =
            //{
            //    new KeyValuePair<int, short>(4, 5), new KeyValuePair<int, short>(7, 5), new KeyValuePair<int, short>(8, 12)
            //};

            // DataAccessObject.AddNewOrder("CHOPS", orderDetails);
            //End Task 9

            //Task 10
            //DataAccessObject.TotalIncome("Charlotte Cooper");
        }
    }
}
