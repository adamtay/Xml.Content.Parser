using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class VendorDto
    {
        [JsonProperty(ExpenseConstants.Vendor)]
        public string Vendor { get; set; }
    }
}