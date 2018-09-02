using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    /// <summary>
    /// Represents the <see cref="CostCentreDto"/> <see cref="object"/>.
    /// </summary>
    public class CostCentreDto
    {
        /// <summary>
        /// Gets or sets the cost centre.
        /// </summary>
        /// <value>
        /// The cost centre.
        /// </value>
        [JsonProperty(ExpenseConstants.CostCentre)]
        public string CostCentre { get; set; }
    }
}