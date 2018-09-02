using System;
using System.Collections.Generic;
using System.Linq;
using Xml.Content.Parser.Common;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Core.Interfaces;

namespace Xml.Content.Parser.Core.Validators
{
    /// <summary>
    /// Responsible for validating the specified message content.
    /// </summary>
    /// <seealso cref="Xml.Content.Parser.Core.Interfaces.IXmlElementValidator" />
    public class ValidXmlElementsValidator : IXmlElementValidator
    {
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidXmlElementsValidator"/> class.
        /// </summary>
        /// <param name="identifyXmlElementsService">The identify XML elements service.</param>
        /// <exception cref="ArgumentNullException">identifyXmlElementsService</exception>
        public ValidXmlElementsValidator(IIdentifyXmlElementsService identifyXmlElementsService)
        {
            if (identifyXmlElementsService == null) throw new ArgumentNullException(nameof(identifyXmlElementsService));

            _identifyXmlElementsService = identifyXmlElementsService;
        }

        /// <summary>
        /// Validates the specified message content.
        /// Ensures that the <see cref="!:messageContent"/> contains valid XML elements.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace. - messageContent</exception>
        /// <exception cref="XmlContentParserException">The specified message contains invalid XML syntax.</exception>
        public void Validate(string messageContent)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));

            bool isValid = ValidateOpeningXmlElements(messageContent) || ValidateClosingXmlElements(messageContent);

            if (!isValid)
            {
                throw new XmlContentParserException("The specified message contains invalid XML syntax.");
            }
        }

        private bool ValidateOpeningXmlElements(string messageContent)
        {
            IEnumerable<string> openingXmlElements = IdentifyXmlElements(messageContent, RegularExpressions.XmlOpenElementRegex).ToList();

            return openingXmlElements.Any() && openingXmlElements.All(HasValidBrackets);
        }

        private bool ValidateClosingXmlElements(string messageContent)
        {
            IEnumerable<string> closingXmlElements = IdentifyXmlElements(messageContent, RegularExpressions.XmlCloseElementRegex).ToList();

            return closingXmlElements.Any() && closingXmlElements.All(xmlElement => HasValidBrackets(xmlElement) && HasClosingTag(xmlElement));
        }

        private IEnumerable<string> IdentifyXmlElements(string messageContent, string regex)
        {
            return _identifyXmlElementsService.IdentifyXmlElements(messageContent, regex);
        }

        private static bool HasValidBrackets(string xmlElement)
        {
            return xmlElement.IndexOf('<') == 0 &&
                   xmlElement.Count(element => element.Equals('<')) == 1 &&
                   xmlElement.IndexOf('>') == xmlElement.Length - 1 &&
                   xmlElement.Count(element => element.Equals('>')) == 1;
        }

        private static bool HasClosingTag(string xmlElement)
        {
            return xmlElement.IndexOf('/') == 1 &&
                   xmlElement.Count(element => element.Equals('/')) == 1;
        }
    }
}