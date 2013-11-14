using System;
using System.Linq;
using System.Runtime.Serialization;

namespace AlbumsDatabase.Model
{
    [DataContract]
    public class Song
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public virtual Album Album { get; set; }

        [DataMember]
        public virtual Artist Artist { get; set; }
    }
}
