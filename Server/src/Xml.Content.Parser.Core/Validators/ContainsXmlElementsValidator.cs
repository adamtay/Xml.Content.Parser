using System;
using System.Linq;
using Xml.Content.Parser.Common;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Core.Interfaces;

namespace Xml.Content.Parser.Core.Validators
{
    public class ContainsXmlElementsValidator : IXmlElementValidator
    {
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;

        public ContainsXmlElementsValidator(IIdentifyXmlElementsService identifyXmlElementsService)
        {
            if (identifyXmlElementsService == null) throw new ArgumentNullException(nameof(identifyXmlElementsService));

            _identifyXmlElementsService = identifyXmlElementsService;
        }

        public void Validate(string messageContent)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));

            bool isValid = HasXmlElements(messageContent, RegularExpressions.XmlOpenElementRegex) &&
                           HasXmlElements(messageContent, RegularExpressions.XmlCloseElementRegex);

            if (!isValid)
            {
                throw new XmlContentParserException("The specified message content does not contain any valid XML elements.");
            }
        }

        private bool HasXmlElements(string messageContent, string regex)
        {
            return _identifyXmlElementsService.Identify(messageContent, regex).Any();
        }
    }
}