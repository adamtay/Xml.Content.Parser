using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    /// <summary>
    /// Represents the <see cref="ExpenseDataDto"/> <see cref="object"/>.
    /// </summary>
    public class ExpenseDataDto
    {
        /// <summary>
        /// Gets or sets the cost centre.
        /// </summary>
        /// <value>
        /// The cost centre.
        /// </value>
        [JsonProperty(ExpenseConstants.CostCentre)]
        public string CostCentre { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        [JsonProperty(ExpenseConstants.Total)]
        public decimal Total { get; set; }

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