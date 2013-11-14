using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace AlbumsDatabase.Model
{
    [DataContract]
    public class Artist
    {
        private ICollection<Album> albums;

        public Artist()
        {
            this.albums = new HashSet<Album>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public int BirthYear { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
