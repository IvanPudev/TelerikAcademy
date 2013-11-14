using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.Client.Models
{
    public class SchoolModelFull : SchoolModel
    {

        public string Location { get; set; }

        public ICollection<Model.Student> Students { get; set; }
    }
}