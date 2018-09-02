using Newtonsoft.Json;
using Xml.Content.Parser.Core.Constants;

namespace Xml.Content.Parser.Core.Domain.XmlContracts
{
    public class ExpenseDto
    {
        [JsonProperty(ExpenseConstants.Expense)]
        public ExpenseDataDto Expense { get; set; }
    }
}