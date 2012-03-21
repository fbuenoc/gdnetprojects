using System.Globalization;
using GDNET.Common.Services;
using WebFramework.Domain;
using WebFramework.Domain.Common;

namespace WebFramework.Services
{
    public class TranslationService : ITranslationService
    {
        public string Translate(string code)
        {
            return Translate(code, string.Empty);
        }

        public string Translate(string code, CultureInfo culture)
        {
            return this.Translate(code, culture.Name);
        }

        private string Translate(string code, string cultureCode)
        {
            if (string.IsNullOrEmpty(code))
            {
                return string.Empty;
            }

            Culture defaultCulture = null;
            if (string.IsNullOrEmpty(cultureCode))
            {
                defaultCulture = DomainRepositories.Culture.GetDefault();
            }
            else
            {
                defaultCulture = DomainRepositories.Culture.FindByCode(cultureCode);
            }

            Translation translation = null;
            if (defaultCulture != null)
            {
                translation = DomainRepositories.Translation.GetByCode(code, defaultCulture);
            }

            return (translation == null) ? string.Format("!{0}!", code) : translation.Value;
        }
    }
}
