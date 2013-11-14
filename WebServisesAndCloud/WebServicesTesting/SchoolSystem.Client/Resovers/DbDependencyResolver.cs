using SchoolSystem.Client.Controllers;
using SchoolSystem.Data;
using SchoolSystem.Model;
using SchoolSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace SchoolSystem.Client.Resovers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(new SchoolSystemRepository<Student>(new SchoolSystemDb()));
            }
            else if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(new SchoolSystemRepository<School>(new SchoolSystemDb()));
            }
            else
            {
                return null;
            }
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