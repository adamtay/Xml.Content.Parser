using System.Collections.Generic;

namespace Xml.Content.Parser.Core.Interfaces
{
    public interface IIdentifyXmlElementsService
    {
        IEnumerable<string> Identify(string messageContent, string regex);
    }
}