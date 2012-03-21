using System.Globalization;
using GDNET.Common.Services;
using GDNET.Extensions;
using WebFramework.Domain;

namespace WebFramework.Services
{
    public class FormatterService : IFormatterService
    {
        /// <summary>
        /// Format a number by default culture
        /// </summary>
        public string FormatNumber(object number)
        {
            var defaultCulture = DomainRepositories.Culture.GetDefault();
            CultureInfo culture = new CultureInfo(defaultCulture.CultureCode);
            return NumberAssistant.ApplyFormat(number, culture);
        }
    }
}
