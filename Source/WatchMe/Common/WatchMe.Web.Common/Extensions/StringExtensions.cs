namespace WatchMe.Web.Common.Extensions
{
    using System.Globalization;

    public static class StringExtensions
    {
        public static string ToTitleString(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }
    }
}
