using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Forum.WebApi.Controllers
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
    }
}
