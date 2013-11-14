using System;
using System.Linq;
using System.Xml.Linq;

public class Program
{
    static void Main()
    {
        XDocument xmlDoc = XDocument.Load("../../../catalog.xml");

        var prices = from album in xmlDoc.Descendants("album")
                     where (DateTime.Now.Year - int.Parse(album.Element("year").Value) >= 5)
                     select album.Element("price").Value;

        foreach (var price in prices)
        {
            Console.WriteLine(price);
        }
    }
}
