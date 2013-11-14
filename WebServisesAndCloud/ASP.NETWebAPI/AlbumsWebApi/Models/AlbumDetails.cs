using AlbumsDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumsWebApi.Models
{
    public class AlbumDetails : AlbumModel
    {
        public AlbumDetails (Album album)
            :base(album)
        {
            foreach (Song song in album.Songs)
            {
                this.Songs.Add(new SongModel(song));
            }

            foreach (Artist artist in album.Artists)
            {
                this.Artists.Add(new ArtistModel(artist));
            }
        }

        public ICollection<SongModel> Songs;

        public ICollection<ArtistModel> Artists;
    }
}