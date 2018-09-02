using System;
using System.Xml;
using Newtonsoft.Json;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Core.Interfaces;

namespace Xml.Content.Parser.Core.Services
{
    public class XmlDeserializerService : IXmlDeserializerService
    {
        public T Deserialize<T>(string messageContent)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(messageContent);

                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeXmlNode(xmlDocument));
            }
            catch (Exception exception)
            {
                throw new XmlContentParserException($"The specified message content could not be deserialized into type: '{typeof(T).Name}'.", exception);
            }
        }
    }
}