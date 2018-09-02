using Newtonsoft.Json;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class CostCentreDto
    {
        [JsonProperty("cost_centre")]
        public string CostCentre { get; set; }
    }
}