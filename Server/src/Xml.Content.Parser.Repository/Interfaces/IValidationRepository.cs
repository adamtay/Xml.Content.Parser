using System.Collections.Generic;

namespace Xml.Content.Parser.Repository.Interfaces
{
    /// <summary>
    /// Responsible for retrieving all applicable validation rules.
    /// </summary>
    public interface IValidationRepository
    {
        /// <summary>
        /// Gets the mandatory XML elements.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetMandatoryXmlElements();
    }
}