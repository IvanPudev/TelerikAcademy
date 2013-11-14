using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class ThreadsController : BaseApiController
    {
        [HttpGet]
        public IQueryable<ThreadDetails> GetAll([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumContext();
                var user = this.GetUser(sessionKey, context);

                var threads = context.Threads;
                var models = context.Threads.Select(ThreadDetails.FromThread);
                return models.OrderByDescending(thr => thr.DateCreated);
            });

            return responseMsg;
        }

        public IQueryable<ThreadModel> GetPage(int page, int count,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Skip(page * count)
                .Take(count);
            return models;
        }

        public IQueryable<ThreadModel> GetByCategory(string category,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Where(thr => thr.Categories.Any(c => c == category));
            return models;
        }

        [ActionName("posts")]
        public IQueryable<PostModel> GetPosts(int threadId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new ForumContext();
            var user = this.GetUser(sessionKey, context);

            var postModels = context.Posts
                .Where(p => p.Thread.Id == threadId)
                .Select(PostModel.FromPost);

            return postModels;
        }

        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage Create(ThreadModel threadModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumContext();

                var user = this.GetUser(sessionKey, context);

                var thread = new Thread()
                {
                    User = user,
                    Content = threadModel.Content,
                    DateCreated = threadModel.DateCreated,
                    Title = threadModel.Title,
                };

                var categories =
                    context.Categories
                    .Where(cat => threadModel.Categories.Any(c => c == cat.Name))
                    .ToList();

                foreach (var categorie in threadModel.Categories)
                {
                    if (!categories.Select(c => c.Name).Contains(categorie))
                    {
                        var cat = new Category() { Name = categorie };
                        context.Categories.Add(cat);
                        categories.Add(cat);
                    }
                }

                thread.Categories = categories;
                context.Threads.Add(thread);
                context.SaveChanges();
                var threadDetails = ThreadDetails.Create(thread);

                var response =
                    this.Request.CreateResponse(HttpStatusCode.Created);
                return response;
            });
            return responseMsg;
        }
    }
}

