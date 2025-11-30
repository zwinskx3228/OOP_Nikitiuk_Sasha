using System;

namespace ClassLibrary8.Extensions
{
    public static class PrimitiveExtensions
    {
        // Для int
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        // Для double
        public static double RoundTo(this double value, int digits)
        {
            return Math.Round(value, digits);
        }

        // Для string
        public static string Capitalize(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}