using Newtonsoft.Json;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class EventDateDto
    {
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}