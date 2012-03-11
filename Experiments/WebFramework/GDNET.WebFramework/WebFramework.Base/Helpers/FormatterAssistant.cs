using System.Globalization;
using GDNET.Extensions;
using WebFramework.Domain.DefaultImpl;

namespace WebFramework.Base.Helpers
{
    public static class FormatterAssistant
    {
        /// <summary>
        /// Format a number by default culture
        /// </summary>
        public static string FormatNumber(object number)
        {
            var defaultCulture = DomainRepositories.Culture.GetDefault();
            CultureInfo culture = new CultureInfo(defaultCulture.CultureCode);
            return NumberAssistant.ApplyFormat(number, culture);
        }
    }
}
