using System;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using TelerikAcademy.Data;

namespace TelerikAcademy.Client
{
    class ClientExec
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();

            #region Task1
            //Using Entity Framework write a SQL query to select all employees from the Telerik Academy
            //database and later print their name, department and town. Try the both variants: with and
            //without .Include(…). Compare the number of executed SQL statements and the performance.

            Stopwatch sw = new Stopwatch();

            sw.Start();

            foreach (var employee in context.Employees)
            {
                Console.WriteLine("Product: {0}, {1}, {2};", employee.FirstName, employee.Department, employee.Address.Town);
            }

            sw.Stop();
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed);
            sw.Reset();

            Console.WriteLine();
            Console.WriteLine("Second select:");
            Console.WriteLine();

            sw.Start();

            foreach (var e in context.Employees.Include("Address"))
            {
                Console.WriteLine("Product: {0}, {1}, {2};", e.FirstName, e.Department, e.Address.Town);
            }

            sw.Stop();
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed);

            //conclusion Include makes the query about 4 times faster. 52 queries when Include used, and 372 when not
            #endregion

            #region Task2

            //Using Entity Framework write a query that selects all employees from the Telerik Academy 
            //database, then invokes ToList(), then selects their addresses, then invokes ToList(), then 
            //selects their towns, then invokes ToList() and finally checks whether the town is "Sofia". 
            //Rewrite the same in more optimized way and compare the performance.

            IEnumerable query = context.Employees.ToList()
                .Select(x => x.Address).ToList()
                .Select(t => t.Town).ToList()
                .Where(t => t.Name == "Sofia");

            foreach (var t in query)
            {
                Console.WriteLine(t);
            } 
            // made 1292 queries

            IEnumerable querySmart = context.Employees
               .Select(x => x.Address)
               .Select(t => t.Town)
               .Where(t => t.Name == "Sofia").ToList();

            foreach (var t in querySmart)
            {
                Console.WriteLine(t);
            } 
            // made 2 queries
            #endregion
        }
    }
}
