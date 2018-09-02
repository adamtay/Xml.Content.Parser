using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class TotalDto
    {
        [JsonProperty(ExpenseConstants.Total)]
        public decimal Total { get; set; }
    }
}