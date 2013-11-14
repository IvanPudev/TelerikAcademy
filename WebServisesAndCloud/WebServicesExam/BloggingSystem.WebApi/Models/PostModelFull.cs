using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystem.WebApi.Models
{
    [DataContract]
    public class PostModelFull
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public DateTime PostedDate { get; set; }

        [DataMember]
        public string PostedBy { get; set; }

        [DataMember]
        public IEnumerable<string> Tags { get; set; }

        [DataMember]
        public IEnumerable<CommentModel> Comments { get; set; }
    }
}