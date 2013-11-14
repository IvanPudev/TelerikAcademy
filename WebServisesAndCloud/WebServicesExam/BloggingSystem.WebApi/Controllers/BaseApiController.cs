using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BloggingSystem.Data;
using BloggingSystem.Model;

namespace BloggingSystem.WebApi.Controllers
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
                var errorResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errorResponse);
            }
        }

        protected User GetUser(string sessionKey, BloggingSystmContext context)
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