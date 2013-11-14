using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.WebAPI.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }
    }

    public class CategoryDetails : CategoryModel
    {
        public int Id { get; set; }

        public virtual ICollection<ThreadModel> Threads { get; set; }
    }
}