using AlbumsDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AlbumsWebApi.Models
{
    [DataContract(Name="artist")]
    public class ArtistModel
    {
        public ArtistModel(Artist artist)
        {
            this.Name = artist.Name;
            this.Country = artist.Country;
            this.BirthYear = artist.BirthYear;
        }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "birth-year")]
        public int BirthYear { get; set; }
    }
}
