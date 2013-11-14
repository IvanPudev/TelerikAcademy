using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsSystem.Model
{
    [Table("Courses")]
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Homework> homeworks;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }

        [Key, Column("CourseID")]
        public int CourseId { get; set; }

        [Column("CourseName")]
        public string Name { get; set; }

        [Column("CourseDescription")]
        public string Description { get; set; }

        [Column("CourseMaterials")]
        public string Materials { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return homeworks; }
            set { homeworks = value; }
        }
    }
}