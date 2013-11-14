using System;
using System.Linq;
using System.Xml;

namespace Task5ExtractAllSongsUsingXmlReader
{
    class ExtractAllSongsUsingXmlReader
    {
        static void Main(string[] args)
        {
            XmlReader reader = XmlReader.Create("../../../catalog.xml");
            using(reader)
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element)&&(reader.Name=="title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
