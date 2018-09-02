using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class ExpenseDataDto
    {
        [JsonProperty(ExpenseConstants.CostCentre)]
        public string CostCentre { get; set; }

        [JsonProperty(ExpenseConstants.Total)]
        public decimal Total { get; set; }

        [JsonProperty(ExpenseConstants.PaymentMethod)]
        public string PaymentMethod { get; set; }
    }
}