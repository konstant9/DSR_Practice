using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCServer.Models;
using Newtonsoft.Json.Linq;

namespace MVCServer.Controllers
{
    public class LoginController : ApiController
    {
        public HttpResponseMessage Post([FromBody] JToken authData)
        {
            try
            {
                Authenticator.Authenticate(authData.Value<string>("Key"), authData.Value<string>("Value"));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ex);
            }
        }
    }
}
