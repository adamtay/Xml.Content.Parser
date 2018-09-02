using Newtonsoft.Json;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class TotalDto
    {
        [JsonProperty("total")]
        public decimal Total { get; set; }
    }
}