using System;
using System.Linq;
using System.Xml.Linq;

namespace Task6ExtractAllSongsUsingXDocument
{
    class ExtractAllSongsUsingXDocument
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("../../../catalog.xml");

            var songs = from song in doc.Descendants("song")
                        select new
                        {
                            Title = song.Element("title").Value
                        };

            foreach (var song in songs)
            {
                Console.WriteLine(song.Title);
            }
        }
    }
}
