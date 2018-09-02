using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    /// <summary>
    /// Represents the <see cref="TotalDto"/> <see cref="object"/>.
    /// </summary>
    public class TotalDto
    {
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        [JsonProperty(ExpenseConstants.Total)]
        public decimal Total { get; set; }
    }
}