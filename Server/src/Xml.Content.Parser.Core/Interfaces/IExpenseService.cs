using Xml.Content.Parser.Core.Domain;

namespace Xml.Content.Parser.Core.Interfaces
{
    public interface IExpenseService
    {
        Expense Extract(string messageContent);
    }
}