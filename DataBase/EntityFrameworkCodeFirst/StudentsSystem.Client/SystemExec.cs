using System;
using System.Linq;
using StudentsSystem.Model;
using StudentsSystem.Data;
using System.Data.Entity;
using StudentsSystem.Data.Migrations;

namespace StudentsSystem.Client
{
    class SystemExec
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemContext, Configuration>());

            StudentsSystemContext db = new StudentsSystemContext();

            var course = new Course();
            course.Name = "Database";
            course.Description = "DB Basics";
            course.Materials = "Some materials";
            db.Courses.Add(course);

            var homework = new Homework();
            homework.Content = "Content";
            homework.TimeSent = DateTime.Now;

            var student = new Student();
            student.Name = "Pesho";
            student.Number = 1234;
            db.Students.Add(student);
            student.Courses.Add(course);
            student.Homelorks.Add(homework);
            
            db.SaveChanges();
        }
    }
}
