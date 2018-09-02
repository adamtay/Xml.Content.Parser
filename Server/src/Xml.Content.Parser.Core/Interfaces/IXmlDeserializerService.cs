namespace Xml.Content.Parser.Core.Interfaces
{
    /// <summary>
    /// Responsible for deserializing XML content.
    /// </summary>
    public interface IXmlDeserializerService
    {
        /// <summary>
        /// Deserializes the specified message content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="messageContent">Content of the message.</param>
        /// <returns></returns>
        T Deserialize<T>(string messageContent);
    }
}