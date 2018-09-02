using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Xml.Content.Parser.Common.Interfaces;

namespace Xml.Content.Parser.API.Middleware
{
    /// <summary>
    /// API middleware for handling any unhandled exceptions.
    /// </summary>
    public class UnhandledExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnhandledExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">
        /// next
        /// or
        /// logger
        /// </exception>
        public UnhandledExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invokes the specified HTTP context and logs any unhandled exceptions.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">httpContext</exception>
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