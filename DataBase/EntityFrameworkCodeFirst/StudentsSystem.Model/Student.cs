using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsSystem.Model
{
    [Table("Students")]
    public class Student
    { 
        private ICollection<Course> courses;

        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        [Key, Column("StudentID")]
        public int StudentId { get; set; }

        [Column("StudentName")]
        public string Name { get; set; }

        [Column("StudentNumber")]
        public int Number { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homelorks
        {
            get { return homeworks; }
            set { homeworks = value; }
        }

    }
}
