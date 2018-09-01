using Newtonsoft.Json;

namespace Xml.Content.Parser.Core.Domain
{
    public class ExpenseDto
    {
        [JsonProperty("expense")]
        public ExpenseDataDto Expense { get; set; }
    }
}