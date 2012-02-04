using System;
using System.Globalization;

namespace GDNET.Extensions
{
    public static class NumberAssistant
    {
        /// <summary>
        /// Format a decimal number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ApplyFormat(this decimal number, CultureInfo culture)
        {
            return string.Format(culture, "{0:#,###}", number);
        }

        /// <summary>
        /// Format a long number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ApplyFormat(this long number, CultureInfo culture)
        {
            return string.Format(culture, "{0:#,###}", number);
        }
    }
}
