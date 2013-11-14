using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace AlbumsDatabase.Model
{
    [DataContract]
    public class Album
    {
        private ICollection<Song> songs;
        private ICollection<Artist> artists;

        public Album()
        {
            this.songs = new HashSet<Song>();
            this.artists = new HashSet<Artist>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public string Producer { get; set; }

        [DataMember]
        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        [IgnoreDataMember]
        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }
    }
}
