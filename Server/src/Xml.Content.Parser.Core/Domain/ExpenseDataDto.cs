using Newtonsoft.Json;

namespace Xml.Content.Parser.Core.Domain
{
    public class ExpenseDataDto
    {
        [JsonProperty("cost_centre")]
        public string CostCentre { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }
    }
}