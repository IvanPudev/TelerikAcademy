using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Forum.Data;
using Forum.Models;

namespace Forum.WebAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }

        protected User GetUser(string sessionKey, ForumContext context)
        {
            var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid username or password");
            }
            return user;
        }
    }
}
