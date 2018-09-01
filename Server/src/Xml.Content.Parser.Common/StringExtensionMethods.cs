using System;

namespace Xml.Content.Parser.Common
{
    public static class StringExtensionMethods
    {
        public static bool EqualsCaseInsensitive(this string value1, string value2)
        {
            if (string.IsNullOrWhiteSpace(value1))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value1));
            if (string.IsNullOrWhiteSpace(value2))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value2));

            return value1.Equals(value2, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}