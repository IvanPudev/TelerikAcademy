using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsSystem.Model
{
    [Table("Homeworks")]
    public class Homework
    {
        [Key, Column("HomeworkID")]
        public int HomeworkId { get; set; }

        [Column("Content")]
        public string Content { get; set; }

        [Column("DateSent")]
        public DateTime? TimeSent { get; set; }
    }
}
