using Forum.Data;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Forum.WebApi.Models
{
    public class ForumDbContextFactory : IDbContextFactory<DbContext>
    {
        public DbContext Create()
        {
            return new ForumContext();
        }
    }
}