using System.Globalization;

namespace Dexter
{
    public static class StringHelper
    {
        private static TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

        public static string? ToTitleCase(this string str)
        {
            return String.IsNullOrEmpty(str) ? null : _textInfo.ToTitleCase(str);
        }
    }
}
