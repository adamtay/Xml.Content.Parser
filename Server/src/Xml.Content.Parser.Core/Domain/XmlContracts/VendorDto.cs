using Newtonsoft.Json;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class VendorDto
    {
        [JsonProperty("vendor")]
        public string Vendor { get; set; }
    }

    public class DescriptionDto
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Date
    {
        [JsonProperty("date")]
        public string LongDateValue { get; set; }
    }
}