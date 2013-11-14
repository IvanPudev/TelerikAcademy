using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BookmarkImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../bookmarks.xml");
            string xPathQuery = "/bookmarks/bookmark";

            XmlNodeList bookmarkList = xmlDoc.SelectNodes(xPathQuery);


        }

        private static XmlNode GetChildText(this XmlNode node, string tagName)
        {
            XmlNode childText = node.SelectSingleNode(tagName);
            return childText;
        }
    }
}
