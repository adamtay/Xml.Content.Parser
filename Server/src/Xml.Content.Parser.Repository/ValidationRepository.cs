using System.Collections.Generic;
using Xml.Content.Parser.Repository.Interfaces;

namespace Xml.Content.Parser.Repository
{
    public class ValidationRepository : IValidationRepository
    {
        public IEnumerable<string> GetMandatoryXmlElements()
        {
            return new List<string>
            {
                "<total>",
                "<cost_centre>"
            };
        }
    }
}