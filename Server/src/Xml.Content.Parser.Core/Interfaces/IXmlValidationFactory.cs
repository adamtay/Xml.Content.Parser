using System.Collections.Generic;

namespace Xml.Content.Parser.Core.Interfaces
{
    /// <summary>
    /// Responsible for initializing all XML validators.
    /// </summary>
    public interface IXmlValidationFactory
    {
        /// <summary>
        /// Creates the XML validators.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IXmlElementValidator> CreateValidators();
    }
}