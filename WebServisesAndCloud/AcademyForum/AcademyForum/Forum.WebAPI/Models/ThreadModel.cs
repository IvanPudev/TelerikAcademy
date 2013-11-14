using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Forum.Models;

namespace Forum.WebAPI.Models
{
    public class ThreadModel
    {
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public string Content { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }

    public class ThreadDetails : ThreadModel
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public IEnumerable<PostModel> Posts { get; set; }

        public static Expression<Func<Thread, ThreadDetails>> FromThread
        {
            get
            {
                return thread => new ThreadDetails()
                {
                    Id = thread.Id,
                    Title = thread.Title,
                    DateCreated = thread.DateCreated,
                    Content = thread.Content,
                    CreatedBy = thread.User.Nickname,
                    Posts = thread.Posts.Select(
                        post => new PostModel()
                        {
                            Content = post.Content,
                            PostDate = post.PostDate,
                            PostedBy = post.User.Nickname,
                            Rating = post.Votes.Count > 0 ? post.Votes.Average(v => v.Value) : 0,
                        }),
                    Categories =
                        (from category in thread.Categories
                         select category.Name),
                };
            }
        }

        public static ThreadDetails Create(Thread thread)
        {
            var threadDetails = new ThreadDetails()
            {
                Id = thread.Id,
                Content = thread.Content,
                DateCreated = thread.DateCreated,
                Title = thread.Title,
                CreatedBy = thread.User.Nickname,
                Categories =
                    (from category in thread.Categories
                     select category.Name),
                Posts =
                    (from post in thread.Posts
                     select new PostModel()
                     {
                         Content = post.Content,
                         PostDate = post.PostDate,
                         PostedBy = post.User.Nickname,
                         Rating = (post.Votes.Count > 0 ? post.Votes.Average(v => v.Value) : 0)
                     }),
            };

            return threadDetails;
        }
    }
}