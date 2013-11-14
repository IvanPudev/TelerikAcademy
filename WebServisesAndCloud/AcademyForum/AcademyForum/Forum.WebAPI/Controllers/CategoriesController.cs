using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Forum.Data;
using Forum.WebAPI.Attributes;

namespace Forum.WebAPI.Controllers
{
    public class CategoriesController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage GetCategories([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumContext();
                var user = this.GetUser(sessionKey, context);

                var categories = context.Categories.Select(cat => cat.Name);

                var response =
                    this.Request.CreateResponse(HttpStatusCode.OK, categories);
                return response;
            });
            return responseMsg;
        }
    }
}
