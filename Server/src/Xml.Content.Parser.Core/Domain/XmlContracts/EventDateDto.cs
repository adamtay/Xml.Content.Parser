using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    /// <summary>
    /// Represents the <see cref="EventDateDto"/> <see cref="object"/>.
    /// </summary>
    public class EventDateDto
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [JsonProperty(ExpenseConstants.Date)]
        public string Date { get; set; }
    }
}