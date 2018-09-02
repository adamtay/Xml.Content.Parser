using System;
using System.Xml;
using Newtonsoft.Json;
using Xml.Content.Parser.Core.Interfaces;

namespace Xml.Content.Parser.Core.Services
{
    public class XmlDeserializerService : IXmlDeserializerService
    {
        public T Deserialize<T>(string messageContent)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(messageContent);

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeXmlNode(xmlDocument));
        }
    }
}