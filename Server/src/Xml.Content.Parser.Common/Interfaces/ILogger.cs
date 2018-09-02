using System;

namespace Xml.Content.Parser.Common.Interfaces
{
    public interface ILogger
    {
        void Log(string message);

        void Log(string message, Exception exception);

        void Log(string message, Exception exception, object rawData);
    }
}