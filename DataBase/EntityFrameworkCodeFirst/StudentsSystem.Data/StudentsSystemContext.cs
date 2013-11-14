using System;
using System.Data.Entity;
using System.Linq;
using StudentsSystem.Model;

namespace StudentsSystem.Data
{
    public class StudentsSystemContext : DbContext
    {
        public StudentsSystemContext()
            : base("StudentsSystem")
        { 

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}