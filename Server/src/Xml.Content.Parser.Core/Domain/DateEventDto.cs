using Newtonsoft.Json;

namespace Xml.Content.Parser.Core.Domain
{
    public class DateEventDto
    {
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}