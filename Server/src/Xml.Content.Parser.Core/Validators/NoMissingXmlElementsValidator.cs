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
    public class NoMissingXmlElementsValidator : IXmlElementValidator
    {
        private readonly IIdentifyXmlElementsService _identifyXmlElementsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoMissingXmlElementsValidator"/> class.
        /// </summary>
        /// <param name="identifyXmlElementsService">The identify XML elements service.</param>
        /// <exception cref="ArgumentNullException">identifyXmlElementsService</exception>
        public NoMissingXmlElementsValidator(IIdentifyXmlElementsService identifyXmlElementsService)
        {
            if (identifyXmlElementsService == null) throw new ArgumentNullException(nameof(identifyXmlElementsService));

            _identifyXmlElementsService = identifyXmlElementsService;
        }

        /// <summary>
        /// Validates the specified message content.
        /// Ensures that the <see cref="!:messageContent"/> contains for all XML elements a corresponding opening and closing XML element pair.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace. - messageContent</exception>
        /// <exception cref="XmlContentParserException">The specified message content contains XML elements without it's corresponding pair.</exception>
        public void Validate(string messageContent)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));

            List<string> missingXmlElements = new List<string>();

            Dictionary<string, int> openingXmlElements = IdentifyXmlElements(messageContent, RegularExpressions.XmlOpenElementRegex);
            Dictionary<string, int> closingXmlElements = IdentifyXmlElements(messageContent, RegularExpressions.XmlCloseElementRegex);

            CheckForMissingXmlElements(openingXmlElements, closingXmlElements, missingXmlElements);
            CheckForMissingXmlElements(closingXmlElements, openingXmlElements, missingXmlElements);

            // TODO: nice to have would be to identify missing corresponding pairs.
            if (missingXmlElements.Any())
            {
                throw new XmlContentParserException("The specified message content contains XML elements without it's corresponding pair.");
            }
        }

        private static void CheckForMissingXmlElements(Dictionary<string, int> xmlElements1, Dictionary<string, int> xmlElements2, List<string> missingXmlElements)
        {
            foreach (KeyValuePair<string, int> xmlElement in xmlElements1)
            {
                string opposingXmlElement = TransformToOpposingXmlElement(xmlElement.Key);

                bool containsOpposingXmlElementKey = xmlElements2.ContainsKey(opposingXmlElement);
                if (!containsOpposingXmlElementKey)
                {
                    missingXmlElements.Add(xmlElement.Key);
                    continue;
                }

                bool matchingElementCount = xmlElements2[opposingXmlElement] == xmlElement.Value;
                if (!matchingElementCount)
                {
                    missingXmlElements.Add(xmlElement.Key);
                }
            }
        }

        private Dictionary<string, int> IdentifyXmlElements(string messageContent, string regex)
        {
            IEnumerable<string> identifyXmlMatches = _identifyXmlElementsService.IdentifyXmlElements(messageContent, regex);

            return identifyXmlMatches.GroupBy(xmlElement => xmlElement)
                .ToDictionary(
                    xmlElement => xmlElement.Key,
                    xmlElement => xmlElement.Count());
        }

        private static string TransformToOpposingXmlElement(string xmlElement)
        {
            bool isClosingXmlElement = xmlElement.IndexOf("/", StringComparison.InvariantCultureIgnoreCase) == 1;

            return isClosingXmlElement ? xmlElement.Remove(1, 1) : xmlElement.Insert(1, "/");
        }
    }
}