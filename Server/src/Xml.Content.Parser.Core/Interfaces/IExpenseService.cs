using Xml.Content.Parser.Core.Domain;

namespace Xml.Content.Parser.Core.Interfaces
{
    /// <summary>
    /// Responsible for all operations against the <see cref="Expense"/> <see cref="object"/>. 
    /// </summary>
    public interface IExpenseService
    {
        /// <summary>
        /// Extracts the specified message content.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <returns></returns>
        Expense Extract(string messageContent);
    }
}