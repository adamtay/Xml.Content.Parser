using System;
using Xml.Content.Parser.Common.Interfaces;

namespace Xml.Content.Parser.Common.Logger
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            // TODO: No op - Log to service such as Raygun/Sentry
        }

        public void Log(string message, Exception exception)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));
            if (exception == null) throw new ArgumentNullException(nameof(exception));

            // TODO: No op - Log to service such as Raygun/Sentry
        }

        public void Log(string message, Exception exception, object rawData)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));
            if (exception == null) throw new ArgumentNullException(nameof(exception));
            if (rawData == null) throw new ArgumentNullException(nameof(rawData));

            // TODO: No op - Log to service such as Raygun/Sentry
        }
    }
}