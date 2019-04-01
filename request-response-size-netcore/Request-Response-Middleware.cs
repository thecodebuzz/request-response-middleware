using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Requestresponsesizesnetcore
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            context.Request.EnableRewind();
            try
            {
                //new MemoryStream. 
                using (var responseBody = new MemoryStream())
                {
                    // temporary response body 
                    context.Response.Body = responseBody;
                    //execute the Middleware pipeline 
                    await _next(context);
                    //read the response stream from the beginning
                    context.Response.Body.Seek(0, SeekOrigin.Begin);
                    //Copy the contents of the new memory stream
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }
    }
}
