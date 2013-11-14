using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Forum.WebApi.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Nickname { get; set; }

        [DataMember]
        public string AuthCode { get; set; }
    }
}