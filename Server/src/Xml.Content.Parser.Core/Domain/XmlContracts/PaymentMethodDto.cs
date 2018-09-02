using Newtonsoft.Json;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class PaymentMethodDto
    {
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }
    }
}