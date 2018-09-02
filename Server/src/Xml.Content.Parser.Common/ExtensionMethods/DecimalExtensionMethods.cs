using System;

namespace Xml.Content.Parser.Common.ExtensionMethods
{
    /// <summary>
    /// Represents the extension methods for <see cref="decimal"/>.
    /// </summary>
    public static class DecimalExtensionMethods
    {
        /// <summary>
        /// Rounds the specified decimal value to a currency format (2 decimal places, rounding away from zero).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static decimal RoundToMoneyValue(this decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}