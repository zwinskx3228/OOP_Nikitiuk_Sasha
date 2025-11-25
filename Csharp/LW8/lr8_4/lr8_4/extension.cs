namespace lr8_4
{
    public static class ExtensionMethods
    {
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }
        public static double Round2(this double value)
        {
            return Math.Round(value, 2);
        }
        public static string Capitalize(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}