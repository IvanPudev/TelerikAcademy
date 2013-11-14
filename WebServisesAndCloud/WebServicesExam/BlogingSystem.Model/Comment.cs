using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using BloggingSystem.Model;

namespace BloggingSystem.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual User User { get; set; }
    }
}
