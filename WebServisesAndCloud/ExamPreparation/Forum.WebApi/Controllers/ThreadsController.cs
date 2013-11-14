using Forum.Data;
using System.Data.Entity;
using Forum.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Forum.WebAPI.Attributes;

namespace Forum.WebApi.Controllers
{
    public class ThreadsController : BaseApiController
    {
        public IQueryable<ThreadModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumContext();

                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new ArgumentNullException("Invalid username or passwprd");
                }

                var threadEntities = context.Threads;
                var models = (from threadEntity in threadEntities
                              select new ThreadModel()
                              {
                                  Id = threadEntity.Id,
                                  Title = threadEntity.Title,
                                  DateCreated = threadEntity.DateCreated,
                                  Content = threadEntity.Content,
                                  CreatedBy = threadEntity.User.Nickname,
                                  Posts = (from postEntity in threadEntity.Posts
                                           select new PostModel()
                                           {
                                               Content = postEntity.Content,
                                               PostDate = postEntity.PostDate,
                                               PostedBy = postEntity.User.Nickname,
                                               //Rating = ((postEntity.Votes.Any()) ? (postEntity.Votes.Average(vote => vote.Value).ToString()) : "0") + "/5"
                                           }),
                                  Categories = (from categoryEntity in threadEntity.Categories
                                                select categoryEntity.Name)
                              });
                return models.OrderByDescending(thr => thr.DateCreated);

            });
            return responseMsg;
        }

        public IQueryable<ThreadModel> GetPage(int page, int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey).Skip(page * count).Take(count);
            return models;
        }

        public IQueryable<ThreadModel> GetByCategory(string category,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey).Where(thr => thr.Categories.Any(c => c == category));
            return models;
        }

        [ActionName("posts")]
        public IQueryable<PostModel> GetPosts(int threadId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new ForumContext();

            var postEntities = context.Threads.FirstOrDefault(thr => thr.Id == threadId).Posts;
            var models = (from postEntity in postEntities
                          select new PostModel()
                          {
                              Content = postEntity.Content,
                              PostDate = postEntity.PostDate,
                              PostedBy = postEntity.User.Nickname,
                              //Rating=postEntity.Votes
                          });
            return models.AsQueryable();
        }
    }
}
