namespace Xml.Content.Parser.Core.Interfaces
{
    public interface IXmlDeserializerService
    {
        T Deserialize<T>(string messageContent);
    }
}