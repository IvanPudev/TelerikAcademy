using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Forum.Models;

namespace Forum.WebAPI.Models
{
    public class PostModel
    {
        public string Content { get; set; }

        public string PostedBy { get; set; }

        public DateTime PostDate { get; set; }

        public double Rating { get; set; }

        public static Expression<Func<Post, PostModel>> FromPost
        {
            get
            {
                return post => new PostModel()
                {
                    Content = post.Content,
                    PostDate = post.PostDate,
                    PostedBy = post.User.Nickname,
                    Rating = post.Votes.Count > 0 ? post.Votes.Average(v => v.Value) : 0
                };
            }
        }
    }
}
