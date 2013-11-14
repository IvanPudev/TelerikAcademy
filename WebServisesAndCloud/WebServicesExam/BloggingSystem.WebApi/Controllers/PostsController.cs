using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BloggingSystem.Data;
using BloggingSystem.Model;
using BloggingSystem.WebApi.Models;

namespace BloggingSystem.WebApi.Controllers
{
    public class PostsController : BaseApiController
    {
        private readonly char[] splitChars = { ' ', ',', ';', '/', '\\', '.', '-', '_', '!', '?', '<', '>', '&', '%', '@' };

        [HttpGet]
        //[ActionName("posts")]
        public IQueryable<PostModelFull> GetAllPosts(string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystmContext();

                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new ArgumentNullException("Invalid username or passwprd");
                }

                var postEntities = context.Posts;
                var models = (from postEntity in postEntities
                              select new PostModelFull()
                              {
                                  Id = postEntity.Id,
                                  Title = postEntity.Title,
                                  PostedBy = postEntity.ByUser.Displayname,
                                  PostedDate = postEntity.DateCreated,
                                  Text = postEntity.Text,
                                  Tags = (from tagEntity in postEntity.Tags
                                          select postEntity.Title),
                                  Comments = (from commentEntity in postEntity.Comments
                                              select new CommentModel()
                                              {
                                                  Text = commentEntity.Text,
                                                  CommentedBy = commentEntity.User.Displayname,
                                                  PostDate = commentEntity.DateCreated
                                              })
                              });
                return models.OrderByDescending(p => p.PostedDate);
            });
            return responseMessage;
        }

        [HttpGet]
        //[ActionName("posts")]
        public IQueryable<PostModelFull> GetPage(int page, int count, string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                var models = this.GetAllPosts(sessionKey).Skip(page * count).Take(count);
                return models;
            });
            return responseMessage;

        }

        [HttpGet]
        //[ActionName("posts")]
        public IQueryable<PostModelFull> GetByKeyword(string keyword, string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                var models = this.GetAllPosts(sessionKey).
                    Where(p => p.Title.ToLower().Split(splitChars).Contains(keyword));
                return models;
            });
            return responseMessage;
        }

        [HttpGet]
        public IQueryable<PostModelFull> GetByTag(string tags, string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                string[] modelTags = tags.Split(',');

                var models = this.GetAllPosts(sessionKey).Where(p => p.Title.Any(t => t == tags));


                return models;
            });
            return responseMessage;
        }

        //TODO
        [HttpPost]
        public HttpResponseMessage PostCreatePost(PostModelFull postModel, string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystmContext();
                using (context)
                {
                    var user = this.GetUser(sessionKey, context);

                    var post = new Post()
                    {
                        ByUser = user,
                        Title = postModel.Title,
                        Text = postModel.Text,
                        DateCreated = DateTime.Now
                    };
                    context.Posts.Add(post);
                    context.SaveChanges();

                    var tags = context.Tags.Where(cat => postModel.Tags.Any(c => c == cat.Name)).ToList();
                    foreach (var tag in postModel.Tags)
                    {
                        if (!tags.Select(c => c.Name).Contains(tag))
                        {
                            var tagToAdd = new Tag() { Name = tag };
                            context.Tags.Add(tagToAdd);
                            tags.Add(tagToAdd);
                        }
                    }

                    post.Tags = tags;
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.Created);
                    return response;
                }
            });
            return responseMessage;
        }


    }
}
