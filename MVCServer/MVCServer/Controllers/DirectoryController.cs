using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using MVCServer.Models;

namespace MVCServer.Controllers
{
    public class DirectoryController : ApiController
    {
        public HttpResponseMessage Get(string path)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, DirectoryItem.DirectoryContents(path + '/'));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ex);
            }
            catch (IOException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ex);
            }
                
        }

        public DriveInfo[] GetDrives()
        {
            return DriveInfo.GetDrives();
        }
    }
}
