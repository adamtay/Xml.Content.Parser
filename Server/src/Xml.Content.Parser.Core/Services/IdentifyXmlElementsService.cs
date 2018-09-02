using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xml.Content.Parser.Core.Interfaces;

namespace Xml.Content.Parser.Core.Services
{
    /// <summary>
    /// Responsible for extracting XML from a specified message content.
    /// </summary>
    /// <seealso cref="Xml.Content.Parser.Core.Interfaces.IIdentifyXmlElementsService" />
    public class IdentifyXmlElementsService : IIdentifyXmlElementsService
    {
        /// <summary>
        /// Identifies the XML elements for the given <see cref="!:regex" />.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <param name="regex">The regex.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// Value cannot be null or whitespace. - messageContent
        /// or
        /// Value cannot be null or whitespace. - regex
        /// </exception>
        public IEnumerable<string> IdentifyXmlElements(string messageContent, string regex)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));
            if (string.IsNullOrWhiteSpace(regex))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(regex));

            MatchCollection xmlmatches = Regex.Matches(messageContent, regex, RegexOptions.Singleline);

            List<string> xmlElements = new List<string>();

            foreach (Match xmlMatch in xmlmatches)
            {
                xmlElements.Add(xmlMatch.Value.ToLowerInvariant());
            }

            return xmlElements;
        }

        /// <summary>
        /// Extracts the content of the XML for the given <see cref="!:regex" /> and <see cref="!:element" />.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <param name="regex">The regex.</param>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// Value cannot be null or whitespace. - messageContent
        /// or
        /// Value cannot be null or whitespace. - regex
        /// </exception>
        public string ExtractXmlContent(string messageContent, string regex, string element)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageContent));
            if (string.IsNullOrWhiteSpace(regex))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(regex));

            return Regex.Match(messageContent, string.Format(regex, element.Replace("<", string.Empty).Replace(">", string.Empty)),
                RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace).Value;
        }
    }
}