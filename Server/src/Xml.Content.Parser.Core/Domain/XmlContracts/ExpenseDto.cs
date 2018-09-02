using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    /// <summary>
    /// Represents the <see cref="ExpenseDto"/> <see cref="object"/>.
    /// </summary>
    public class ExpenseDto
    {
        /// <summary>
        /// Gets or sets the expense.
        /// </summary>
        /// <value>
        /// The expense.
        /// </value>
        [JsonProperty(ExpenseConstants.Expense)]
        public ExpenseDataDto Expense { get; set; }
    }
}