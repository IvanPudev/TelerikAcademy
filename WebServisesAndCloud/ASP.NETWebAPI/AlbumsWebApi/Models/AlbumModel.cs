using AlbumsDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AlbumsWebApi.Models
{
    [DataContract(Name="album")]
    public class AlbumModel
    {
        public AlbumModel(Album album)
        {
            this.Title = album.Title;
            this.Producer = album.Producer;
            this.Year = album.Year;
        }

        [DataMember(Name="title")]
        public string Title { get; set; }

        [DataMember(Name = "producer")]
        public string Producer { get; set; }

        [DataMember(Name = "year")]
        public int Year { get; set; }
    }
}