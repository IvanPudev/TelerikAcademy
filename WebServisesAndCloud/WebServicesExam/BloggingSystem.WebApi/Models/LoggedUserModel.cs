using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystem.WebApi.Models
{
    [DataContract]
    public class LoggedUserModel
    {
        [DataMember]
        public string Displayname { get; set; }

        [DataMember]
        public string SessionKey { get; set; }

    }
}