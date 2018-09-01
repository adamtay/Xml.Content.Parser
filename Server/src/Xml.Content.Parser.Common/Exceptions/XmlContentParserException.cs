using System;
using System.Runtime.Serialization;

namespace Xml.Content.Parser.Common.Exceptions
{
    public class XmlContentParserException : Exception
    {
        public XmlContentParserException()
        {
        }

        public XmlContentParserException(string message) : base(message)
        {
        }

        public XmlContentParserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected XmlContentParserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}