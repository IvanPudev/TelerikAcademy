using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Forum.Data;
using Forum.Models;
using Forum.WebAPI.Attributes;
using Forum.WebAPI.Models;

namespace Forum.WebAPI.Controllers
{
    public class PostsController : BaseApiController
    {
        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage Create(PostModel postModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumContext();
                var user = this.GetUser(sessionKey, context);

                var post = new Post()
                {
                    Content = postModel.Content,
                    PostDate = postModel.PostDate,
                    User = user
                };

                context.Posts.Add(post);
                context.SaveChanges();

                var response =
                    this.Request.CreateResponse(HttpStatusCode.Created);
                return response;
            });
            return responseMsg;
        }

        [HttpGet]
        [ActionName("vote")]
        public HttpResponseMessage GetVotes(int postId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {


                var response =
                    this.Request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
            return responseMsg;
        }

        [HttpGet]
        [ActionName("comment")]
        public HttpResponseMessage GetComments(int postId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {


                var response =
                    this.Request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
            return responseMsg;
        }
    }
}
