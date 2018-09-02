using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class PaymentMethodDto
    {
        [JsonProperty(ExpenseConstants.PaymentMethod)]
        public string PaymentMethod { get; set; }
    }
}