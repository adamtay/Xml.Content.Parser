using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class EventDateDto
    {
        [JsonProperty(ExpenseConstants.Date)]
        public string Date { get; set; }
    }
}