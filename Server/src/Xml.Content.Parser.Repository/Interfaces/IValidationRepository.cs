using System.Collections.Generic;

namespace Xml.Content.Parser.Repository.Interfaces
{
    public interface IValidationRepository
    {
        IEnumerable<string> GetMandatoryXmlElements();
    }
}