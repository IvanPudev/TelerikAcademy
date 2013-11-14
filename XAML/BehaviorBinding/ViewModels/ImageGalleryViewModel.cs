using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ImageGalleryViewModel
    {
        public string CountriesDocumentPath { get; set; }

        private ObservableCollection<AlbumViewModel> albums;

        public ObservableCollection<AlbumViewModel> Albums
        {
            get
            {
                if (this.albums == null)
                {
                    var albumsEnumerable = DataPersister.GetAll(CountriesDocumentPath);
                    this.albums = new ObservableCollection<AlbumViewModel>();
                    foreach (var album in albumsEnumerable)
                    {
                        this.albums.Add(album);
                    }
                   
                }

                return albums;
            }
        }

        public ImageGalleryViewModel()
        {
            this.CountriesDocumentPath = "..\\..\\..\\ViewModels\\gallery.xml";
        }
    }
}
