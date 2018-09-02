using System.Collections.Generic;

namespace Xml.Content.Parser.Core.Interfaces
{
    public interface IXmlValidationFactory
    {
        IEnumerable<IXmlElementValidator> CreateValidators();
    }
}