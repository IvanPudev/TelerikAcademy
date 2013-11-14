using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModels
{
    public class DataPersister
    {
        public static IEnumerable<AlbumViewModel> GetAll(string galleryPath)
        {
            var galleryDocumentRoot = XDocument.Load(galleryPath).Root;
            var albums =
                            from album in galleryDocumentRoot.Elements("album")
                            select new AlbumViewModel()
                            {
                                Name = album.Element("name").Value,
                                ImagesEnum = from image in album.Element("images").Elements("image")
                                         select new ImageViewModel()
                                         {
                                             Title = image.Element("title").Value,
                                             Source = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), image.Element("source").Value)
                                         }
                            };
            return albums;
        }
    }
}
