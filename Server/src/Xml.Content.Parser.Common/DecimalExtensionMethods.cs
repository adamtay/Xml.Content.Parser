using System;

namespace Xml.Content.Parser.Common
{
    public static class DecimalExtensionMethods
    {
        public static decimal RoundToMoneyValue(this decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}