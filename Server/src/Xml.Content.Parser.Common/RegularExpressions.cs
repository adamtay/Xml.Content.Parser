namespace Xml.Content.Parser.Common
{
    /// <summary>
    /// Represents the regular exceptions used by the solution.
    /// </summary>
    public class RegularExpressions
    {
        /// <summary>
        /// XML open element regex.
        /// The regex '\w' is used to find a word character.
        /// </summary>
        public const string XmlOpenElementRegex = "<(\\w+)>";

        /// <summary>
        /// XML close element regex.
        /// The regex '\w' is used to find a word character.
        /// </summary>
        public const string XmlCloseElementRegex = "</(\\w+)>";

        /// <summary>
        /// XML content regex.
        /// The string parameter {0} denotes the string template replacement.
        /// The regex '.*?' denotes for any words or characters.
        /// </summary>
        public const string XmlContentRegex = "<{0}>(.*?)</{0}>";
    }
}