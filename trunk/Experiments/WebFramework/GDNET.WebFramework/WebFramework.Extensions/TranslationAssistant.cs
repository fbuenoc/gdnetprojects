using WebFramework.Base.Framework.Base;
using WebFramework.Domain.DefaultImpl;

namespace WebFramework.Extensions
{
    public static class TranslationAssistant
    {
        public static string Translate(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                var defaultCulture = DomainRepositories.Culture.GetDefault();
                var translation = DomainRepositories.Translation.GetByCode(code, defaultCulture);
                return (translation == null) ? string.Format("!{0}!", code) : translation.Value;
            }

            return string.Empty;
        }

        public static string CreateOrUpdate<TId>(IViewModel<TId> viewModel)
        {
            string code = (viewModel.Id.Equals(default(TId))) ? "ApplicationCategories.SysTranslation.Create" : "ApplicationCategories.SysTranslation.Update";
            return TranslationAssistant.Translate(code);
        }
    }
}
