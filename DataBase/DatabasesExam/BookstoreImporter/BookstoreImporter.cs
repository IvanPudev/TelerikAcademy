using System;
using System.Linq;
using System.Xml;

namespace Bookstore.Client
{
    static class BookstoreImporter
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../simple-books.xml");

            string xPathQuery = "catalog/book";
            XmlNodeList booksList = doc.SelectNodes(xPathQuery);

            foreach (XmlNode node in booksList)
            {
                string author = GetChildText(node, "author");
                string title = GetChildText(node, "title");
                string isbn = GetChildText(node, "isbn");
                string price = GetChildText(node, "price");
                string webSite = GetChildText(node, "web-site");

                Bookstore.Data.Bookstore.AddBook(author, title, isbn, price, webSite);
            }

            XmlDocument complexDoc = new XmlDocument();
            complexDoc.Load("../../complex-books.xml");

            XmlNodeList complexBooksList = complexDoc.SelectNodes(xPathQuery);

            foreach (XmlNode node in complexBooksList)
            {

            }

            XmlDocument simpleSearchDoc = new XmlDocument();
            simpleSearchDoc.Load("../../simple-query.xml");
            string searchQuery = "query";
            XmlNodeList nodes = simpleSearchDoc.SelectNodes(searchQuery);

            string bookAuthor = simpleSearchDoc.GetChildText("author");
            string bookName = simpleSearchDoc.GetChildText("title");
            string bookIsbn = simpleSearchDoc.GetChildText("isbn");
            var books =
                Bookstore.Data.Bookstore.FindBooksByAuthorNameOrIsbn(
                    bookAuthor, bookName, bookIsbn);
            if (books.Count > 0)
            {
                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                }
            }
            else
            {
                Console.WriteLine("Nothing found");
            }
        }



        private static string GetChildText(this XmlNode node, string childName)
        {
            XmlNode childNode = node.SelectSingleNode(childName);
            if (childNode == null)
            {
                return null;
            }
            return childNode.InnerText;
        }

       
    }
    
}
