using System;
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
    public class ContainsXmlElementsValidator : IXmlElementValidator
    {
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainsXmlElementsValidator"/> class.
        /// </summary>
        /// <param name="identifyXmlElementsService">The identify XML elements service.</param>
        /// <exception cref="ArgumentNullException">identifyXmlElementsService</exception>
        public ContainsXmlElementsValidator(IIdentifyXmlElementsService identifyXmlElementsService)
        {
            if (identifyXmlElementsService == null) throw new ArgumentNullException(nameof(identifyXmlElementsService));

            _identifyXmlElementsService = identifyXmlElementsService;
        }

        /// <summary>
        /// Validates the specified message content.
        /// Ensures that the <see cref="!:messageContent"/> contains an opening and closing XML element.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace. - messageContent</exception>
        /// <exception cref="XmlContentParserException">The specified message content does not contain any valid XML elements.</exception>
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
            return _identifyXmlElementsService.IdentifyXmlElements(messageContent, regex).Any();
        }
    }
}