using System;

namespace Xml.Content.Parser.Common.Interfaces
{
    /// <summary>
    /// Responsible for logging messages and exception handling.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Log(string message);

        /// <summary>
        /// Logs the specified message and exception stack trace.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Log(string message, Exception exception);

        /// <summary>
        /// Logs the specified message, exception stack trace and the <see cref="object"/> raw data.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="rawData">The raw data.</param>
        void Log(string message, Exception exception, object rawData);
    }
}