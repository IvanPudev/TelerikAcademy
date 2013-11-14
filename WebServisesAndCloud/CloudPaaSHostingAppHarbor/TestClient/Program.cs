using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeJewelData;
using CodeJewelModels;
using System.Data.Entity;
using CodeJewelData.Migrations;

namespace TestClient
{
    class Program
    {
                   
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CodeContext, Configuration>());
            var context = new CodeContext();
            //var cat = new Category
            //{
            //    Name="Just category"
            //};
            //context.Categories.Add(cat);
           // context.SaveChanges();

            var cats = from c in context.Categories
                       select c;
            foreach (var c in cats)
            {
                Console.WriteLine(c.Id);
                Console.WriteLine(c.Name);
            }
        }
    }
}
