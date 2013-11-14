using System;
using System.Linq;
using System.Xml;

namespace Task4DeletingWithDOMParser
{
    class DeletingWithDOMParser
    {
        static void Main(string[] args)
        {
            const int PriceBounder = 20;
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            {
                var node = rootNode.ChildNodes[i];
                int price = int.Parse(node["price"].InnerText);

                if (price > PriceBounder)
                {
                    rootNode.RemoveChild(node);
                    i--;
                }
            }

            doc.Save("../../newCatalog.xml");
        }
    }
}
