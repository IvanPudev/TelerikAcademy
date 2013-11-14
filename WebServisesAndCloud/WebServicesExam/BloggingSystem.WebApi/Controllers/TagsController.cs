using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using BloggingSystem.Data;
using BloggingSystem.Model;
using BloggingSystem.WebApi.Models;

namespace BloggingSystem.WebApi.Controllers
{
    public class TagsController : BaseApiController
    {
        public IQueryable<TagsModelFull> GetAllTags(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystmContext();

                using(context)
                {
                    var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new ArgumentNullException("Invalid username or passwprd");
                    }

                    var tagsEntities = context.Tags;
                    var models = (from tagEntity in tagsEntities
                                  select new TagsModelFull()
                                  {
                                      Id = tagEntity.Id,
                                      Name = tagEntity.Name
                                  });
                }


                var response =
                    this.Request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
            return responseMsg;
        }
    }
}
