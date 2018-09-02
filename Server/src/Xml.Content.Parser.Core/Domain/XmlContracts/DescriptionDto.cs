using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    /// <summary>
    /// Represents the <see cref="DescriptionDto"/> <see cref="object"/>.
    /// </summary>
    public class DescriptionDto
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty(ExpenseConstants.Description)]
        public string Description { get; set; }
    }
}