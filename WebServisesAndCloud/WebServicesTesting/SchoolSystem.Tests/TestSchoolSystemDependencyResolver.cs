using SchoolSystem.Client.Controllers;
using SchoolSystem.Data;
using SchoolSystem.Model;
using SchoolSystem.Repository;
using SchoolSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace SchoolSystem.Tests
{
    public class TestSchoolSystemDependencyResolver<T> : IDependencyResolver
    {
        private IRepository<T> repository;

        public IRepository<T> Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(this.Repository as IRepository<School>);
            }
            else if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(this.Repository as IRepository<Student>);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {

        }
    }
}
