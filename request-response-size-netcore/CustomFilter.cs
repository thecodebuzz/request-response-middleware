using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace request_response_size_netcore.Filters
{
    public class CustomFilter : ActionFilterAttribute
    {
        public static ILogger _logger;
        public CustomFilter()
        {
            _logger = new LoggerFactory().AddConsole().CreateLogger(typeof(CustomFilter));
        }
        public override void OnResultExecuted(ResultExecutedContext contextResult)
        {
            if (contextResult != null && contextResult.ModelState.IsValid)
            {
                if (contextResult.HttpContext.Request.Body.CanRead && contextResult.HttpContext.Request.Body.CanSeek)
                {
                    float requestSize = (float)contextResult.HttpContext.Request.Body.Length / 1024;
                    float responseSize = (float)contextResult.HttpContext.Request.Body.Length / 1024;
                    
                    _logger.LogInformation($"Request size: {requestSize} kb");
                    _logger.LogInformation($"Response size: {responseSize} kb");
                }
            }
        }
        private static string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

    }
}

