using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    /// <summary>
    /// Represents the <see cref="PaymentMethodDto"/> <see cref="object"/>.
    /// </summary>
    public class PaymentMethodDto
    {
        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        /// <value>
        /// The payment method.
        /// </value>
        [JsonProperty(ExpenseConstants.PaymentMethod)]
        public string PaymentMethod { get; set; }
    }
}