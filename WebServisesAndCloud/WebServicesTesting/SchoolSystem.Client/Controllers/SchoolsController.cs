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
    public class SchoolsController : ApiController
    {
        private readonly IRepository<School> data;

        public SchoolsController(IRepository<School> data)
        {
            this.data = data;
        }

        //api/schools
        public IQueryable<SchoolModel> GetAll()
        {
            IQueryable<School> schools = this.data.All();
            IQueryable<SchoolModel> convertedSchools = SchoolsConvert(schools);
            return convertedSchools;
        }

        //api/schools/5
        public SchoolModelFull GetSchool(int id)
        {
            School school = this.data.Get(id);
            var schoolModel = new SchoolModelFull()
            {
                Id = school.Id,
                Name = school.Name,
                Location = school.Location,
                Students = school.Students
            };
            return schoolModel;
        }

        //api/schools
        public HttpResponseMessage PostSchool(SchoolModelFull model)
        {
            School school = DeserializeFromModel(model);
            this.data.Add(school);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + school.Id.ToString(CultureInfo.InvariantCulture));
            return message;
        }

        private School DeserializeFromModel(SchoolModelFull model)
        {
            School school = new School()
            {
                Id = model.Id,
                Name = model.Name,
                Location = model.Location,
                Students = model.Students
            };
            return school;
        }

        private IQueryable<SchoolModel> SchoolsConvert(IQueryable<School> schools)
        {
            var schoolModels = from school in schools
                               select new SchoolModel()
                               {
                                   Id = school.Id,
                                   Name = school.Name
                               };
            return schoolModels;
        }
    }
}
