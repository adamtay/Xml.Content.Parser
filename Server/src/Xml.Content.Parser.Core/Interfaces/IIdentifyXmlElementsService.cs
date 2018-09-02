using System.Collections.Generic;

namespace Xml.Content.Parser.Core.Interfaces
{
    /// <summary>
    /// Responsible for extracting XML from a specified message content.
    /// </summary>
    public interface IIdentifyXmlElementsService
    {
        /// <summary>
        /// Identifies the XML elements for the given <see cref="!:regex"/>.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <param name="regex">The regex.</param>
        /// <returns></returns>
        IEnumerable<string> IdentifyXmlElements(string messageContent, string regex);

        /// <summary>
        /// Extracts the content of the XML for the given <see cref="!:regex"/> and <see cref="!:element"/>.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <param name="regex">The regex.</param>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        string ExtractXmlContent(string messageContent, string regex, string element);
    }
}