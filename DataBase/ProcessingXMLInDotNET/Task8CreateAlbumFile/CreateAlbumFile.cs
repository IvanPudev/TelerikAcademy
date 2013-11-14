using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task8CreateAlbumFile
{
    class CreateAlbumFile
    {
        static void Main(string[] args)
        {
            XmlReader reader = XmlReader.Create("../../../catalog.xml");
            using (reader)
            {
                while (reader.Read())
                {

                }
            }
        }
    }
}
