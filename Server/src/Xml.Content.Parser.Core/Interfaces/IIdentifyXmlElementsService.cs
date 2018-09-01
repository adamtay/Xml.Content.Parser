using System.Collections.Generic;

namespace Xml.Content.Parser.Core.Interfaces
{
    public interface IIdentifyXmlElementsService
    {
        IEnumerable<string> IdentifyXmlElements(string messageContent, string regex);
        string ExtractXmlContent(string messageContent, string regex, string element);
    }
}