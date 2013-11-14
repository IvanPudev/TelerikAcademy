using AlbumsDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AlbumsWebApi.Models
{
    [DataContract(Name = "song")]
    public class SongModel
    {
        public SongModel(Song song)
        {
            this.Title = song.Title;
            this.Year = song.Year;
            this.Genre = song.Genre;

            if (song.Artist != null)
            {
                this.Artist = new ArtistModel(song.Artist);
            }

            if (song.Album != null)
            {
                this.Album = new AlbumModel(song.Album);
            }
        }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "year")]
        public int Year { get; set; }

        [DataMember(Name = "genre")]
        public string Genre { get; set; }

        [DataMember(Name = "artist")]
        public ArtistModel Artist { get; set; }

        [DataMember(Name = "album")]
        public AlbumModel Album { get; set; }
    }
}
