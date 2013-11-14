using SchoolSystem.Client.Models;
using SchoolSystem.Model;
using SchoolSystem.Repository.Interfaces;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolSystem.Client.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IRepository<Student> data;

        public StudentsController(IRepository<Student> data)
        {
            this.data = data;
        }

        //api/students
        public IQueryable<StudentModel> GetAll()
        {
            IQueryable<Student> students = this.data.All();
            IQueryable<StudentModel> convertedStudents = ConvertStudents(students);
            return convertedStudents;
        }

        //api/students/5
        public StudentModelFull GetStudent(int id)
        {
            Student student = this.data.Get(id);
            StudentModelFull studentModel = new StudentModelFull()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Grade = student.Grade,
                School = student.School,
                Marks = student.Marks
            };
            return studentModel;
        }

        //api/students
        public HttpResponseMessage Post([FromBody]StudentModel model)
        {
            Student student = DeserializeFromModel(model);
            this.data.Add(student);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + student.Id.ToString(CultureInfo.InvariantCulture));
            return message;
        }

        private Student DeserializeFromModel(StudentModel model)
        {
            Student student = new Student()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Grade = model.Grade
            };
            return student;
        }

        private IQueryable<StudentModel> ConvertStudents(IQueryable<Student> students)
        {
            var studentModels = from student in students
                                select new StudentModel()
                                {
                                    Id = student.Id,
                                    FirstName = student.FirstName,
                                    LastName = student.LastName,
                                    Age = student.Age,
                                };
            return studentModels;
        }
    }
}
