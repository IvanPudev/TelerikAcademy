using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using SchoolSystem.Repository.Interfaces;
using SchoolSystem.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SchoolSystem.Tests
{
    [TestClass]
    public class TestSchoolSystem
    {
        [TestMethod]
        public void GetAll_WhenOneSchool_Returns_Status200()
        {
            var repository = Mock.Create<IRepository<School>>();
            var models = new List<School>();
            models.Add(new School()
            {
                Name = "TestName"
            });
            
            Mock.Arrange(() => repository.All()).Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<School>("http://localhost/",
                repository);

            var response = server.CreateGetRequest("api/schools");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetAll_WhenOneStudent_Returns_Status200()
        {
            var repository = Mock.Create<IRepository<Student>>();
            var models = new List<Student>();
            models.Add(new Student()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Age = 15,
                Grade = 9
            });

            Mock.Arrange(() => repository.All()).Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                repository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Post_WhenSchoolCreated_Returns_Status201()
        {
            var repository = Mock.Create<IRepository<School>>();
            Mock.Arrange(() => repository.Add(Arg.Matches<School>(school => school.Name == "TestName")));

            var server = new InMemoryHttpServer<School>("http://localhost/", repository);

            var response = server.CreatePostRequest("api/Schools",
                new School()
                {
                    Name = "TestName"
                });

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void PostSschool_WhenNameIsNull_ShouldReturnStatusCode400()
        {
            var repository = Mock.Create<IRepository<School>>();

            Mock.Arrange(() => repository
                .Add(Arg.Matches<School>(school => school.Name == null)))
                    .Throws<NullReferenceException>();


            var server = new InMemoryHttpServer<School>("http://localhost/", repository);

            var response = server.CreatePostRequest("api/Schools",
                new School()
                {
                    Name = null
                });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
