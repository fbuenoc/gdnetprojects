using WebFramework.Base.Framework.Base;
using WebFramework.Domain.DefaultImpl;

namespace WebFramework.Base.Helpers
{
    public static class TranslationAssistant
    {
        public static string Translate(string code)
        {
            var defaultCulture = DomainRepositories.Culture.GetDefault();

            if (string.IsNullOrEmpty(code))
            {
                return string.Empty;
            }

            var translation = DomainRepositories.Translation.GetByCode(code, defaultCulture);
            return (translation == null) ? string.Format("!{0}!", code) : translation.Value;
        }

        public static string CreateOrUpdate<TId>(IViewModel<TId> viewModel)
        {
            string code = (viewModel.Id.Equals(default(TId))) ? "SysTranslation.Create" : "SysTranslation.Update";
            return TranslationAssistant.Translate(code);
        }
    }
}
