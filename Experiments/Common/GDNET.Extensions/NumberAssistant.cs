using System.Globalization;

namespace GDNET.Extensions
{
    public static class NumberAssistant
    {
        /// <summary>
        /// Format a decimal number
        /// </summary>
        public static string ApplyFormat(this decimal number, CultureInfo culture)
        {
            return string.Format(culture, "{0:#.##}", number);
        }

        /// <summary>
        /// Format a long number
        /// </summary>
        public static string ApplyFormat(this long number, CultureInfo culture)
        {
            return string.Format(culture, "{0:#.##}", number);
        }

        /// <summary>
        /// Format a number
        /// </summary>
        public static string ApplyFormat(object number, CultureInfo culture)
        {
            return string.Format(culture, "{0:#.##}", number);
        }

        /// <summary>
        /// Returns value of type 'long', MinValue by default.
        /// </summary>
        public static long ToLong(this string value)
        {
            long result;
            if (long.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return long.MinValue;
            }
        }
    }
}
