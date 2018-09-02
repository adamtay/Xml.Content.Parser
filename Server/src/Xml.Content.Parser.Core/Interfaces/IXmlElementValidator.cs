namespace Xml.Content.Parser.Core.Interfaces
{
    /// <summary>
    /// Responsible for validating the specified message content.
    /// </summary>
    public interface IXmlElementValidator
    {
        /// <summary>
        /// Validates the specified message content.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        void Validate(string messageContent);
    }
}