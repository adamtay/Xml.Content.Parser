namespace Xml.Content.Parser.Common
{
    public class RegularExpressions
    {
        public const string XmlOpenElementRegex = "<(\\w+)>";

        public const string XmlCloseElementRegex = "</(\\w+)>";

        public const string XmlContentRegex = "<{0}>(.*?)</{0}>";
    }
}