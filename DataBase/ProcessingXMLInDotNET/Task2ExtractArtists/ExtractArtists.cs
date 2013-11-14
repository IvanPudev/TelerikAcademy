using System;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace Task2ExtractArtists
{
    //Write program that extracts all different artists which are found in the catalog.xml.
    //For each author you should print the number of albums in the catalogue. 
    //Use the DOM parser and a hash-table.

    class ExtractArtists
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;
            Dictionary<string, int> artists = new Dictionary<string, int>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                string artist = node["artist"].InnerText;
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
