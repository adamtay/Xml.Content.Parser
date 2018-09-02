using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xml.Content.Parser.Core.Interfaces;

namespace Xml.Content.Parser.Core.Services
{
    public class IdentifyXmlElementsService : IIdentifyXmlElementsService
    {
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