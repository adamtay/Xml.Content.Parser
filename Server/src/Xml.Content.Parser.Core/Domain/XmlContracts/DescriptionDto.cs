using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class DescriptionDto
    {
        [JsonProperty(ExpenseConstants.Description)]
        public string Description { get; set; }
    }
}