using System.Web.Mvc;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkExtensions
{
    public static class TranslationAssistant
    {
        public static string Translate(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                var translation = DomainRepositories.Translation.GetByCode(code);
                return (translation == null) ? string.Format("!{0}!", code) : translation.Value;
            }

            return string.Empty;
        }
    }
}
