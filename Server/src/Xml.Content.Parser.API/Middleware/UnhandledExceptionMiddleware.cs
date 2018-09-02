using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Xml.Content.Parser.Common.Interfaces;

namespace Xml.Content.Parser.API.Middleware
{
    public class UnhandledExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public UnhandledExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                _logger.Log("Unhandled API Exception.", exception);
            }
        }
    }
}