using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Task3ExtractArtistsUsingXPath
{
    class ExtractArtistsUsingXPath
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            string xPathQuery = "catalog/album";
            XmlNodeList artistsList = doc.SelectNodes(xPathQuery);

            Dictionary<string, int> artists = new Dictionary<string, int>();

            foreach (XmlNode node in artistsList)
            {
                string artist = node.SelectSingleNode("artist").InnerText;
                if (!artists.ContainsKey(artist))
                {
                    artists.Add(artist, 0);
                }
                artists[artist]++;
            }

            foreach (var artist in artists)
            {
                Console.WriteLine(string.Join(" - ", artist.Key, artist.Value));
            }
        }
    }
}