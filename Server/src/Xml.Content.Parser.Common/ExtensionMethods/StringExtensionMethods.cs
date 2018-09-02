using System;

namespace Xml.Content.Parser.Common.ExtensionMethods
{
    /// <summary>
    /// Represents the extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtensionMethods
    {
        /// <summary>
        /// Determines whether this string and the specified <see cref="string"/> object have the same value case insensitive.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// Value cannot be null or whitespace. - value1
        /// or
        /// Value cannot be null or whitespace. - value2
        /// </exception>
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