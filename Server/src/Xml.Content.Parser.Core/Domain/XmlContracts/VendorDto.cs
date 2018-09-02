using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    /// <summary>
    /// Represents the <see cref="VendorDto"/> <see cref="object"/>.
    /// </summary>
    public class VendorDto
    {
        /// <summary>
        /// Gets or sets the vendor.
        /// </summary>
        /// <value>
        /// The vendor.
        /// </value>
        [JsonProperty(ExpenseConstants.Vendor)]
        public string Vendor { get; set; }
    }
}