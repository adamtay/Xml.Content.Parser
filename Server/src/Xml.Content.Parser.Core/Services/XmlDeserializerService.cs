using System;
using System.Xml;
using Newtonsoft.Json;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Core.Interfaces;

namespace Xml.Content.Parser.Core.Services
{
    /// <summary>
    /// Responsible for deserializing XML content.
    /// </summary>
    /// <seealso cref="Xml.Content.Parser.Core.Interfaces.IXmlDeserializerService" />
    public class XmlDeserializerService : IXmlDeserializerService
    {
        /// <summary>
        /// Deserializes the specified message content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="messageContent">Content of the message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace. - messageContent</exception>
        /// <exception cref="XmlContentParserException"></exception>
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