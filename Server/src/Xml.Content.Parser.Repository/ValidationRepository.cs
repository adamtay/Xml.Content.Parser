using System.Collections.Generic;
using Xml.Content.Parser.Repository.Interfaces;

namespace Xml.Content.Parser.Repository
{
    /// <summary>
    /// Responsible for retrieving all applicable validation rules.
    /// </summary>
    /// <seealso cref="Xml.Content.Parser.Repository.Interfaces.IValidationRepository" />
    public class ValidationRepository : IValidationRepository
    {
        /// <summary>
        /// Gets the mandatory XML elements.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetMandatoryXmlElements()
        {
            return new List<string>
            {
                "<total>"
            };
        }
    }
}