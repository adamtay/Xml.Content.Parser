using System;
using System.Collections.Generic;
using Xml.Content.Parser.Core.Factories;
using Xml.Content.Parser.Core.Interfaces;

namespace Xml.Content.Parser.Core.Services
{
    public class XmlExtractionService
    {
        private readonly IXmlValidationFactory _xmlValidationFactory;

        public XmlExtractionService(IXmlValidationFactory xmlValidationFactory)
        {
            _xmlValidationFactory = xmlValidationFactory;
        }

        public void Extract(string messageContent)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));

            ValidateMessageContent(messageContent);
        }

        private void ValidateMessageContent(string messageContent)
        {
            IEnumerable<IXmlElementValidator> xmlElementValidators = _xmlValidationFactory.CreateValidators();

            foreach (IXmlElementValidator xmlElementValidator in xmlElementValidators)
            {
                xmlElementValidator.Validate(messageContent);
            }
        }
    }
}