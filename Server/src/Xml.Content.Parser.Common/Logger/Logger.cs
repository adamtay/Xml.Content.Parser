using System;
using Xml.Content.Parser.Common.Interfaces;

namespace Xml.Content.Parser.Common.Logger
{
    /// <summary>
    /// Responsible for logging messages and exception handling.
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace. - message</exception>
        public void Log(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            // TODO: No op - Log to service such as Raygun/Sentry
        }

        /// <summary>
        /// Logs the specified message and exception stack trace.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace. - message</exception>
        /// <exception cref="ArgumentNullException">exception</exception>
        public void Log(string message, Exception exception)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));
            if (exception == null) throw new ArgumentNullException(nameof(exception));

            // TODO: No op - Log to service such as Raygun/Sentry
        }

        /// <summary>
        /// Logs the specified message, exception stack trace and the <see cref="object" /> raw data.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="rawData">The raw data.</param>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace. - message</exception>
        /// <exception cref="ArgumentNullException">
        /// exception
        /// or
        /// rawData
        /// </exception>
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