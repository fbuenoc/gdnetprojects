using WebFramework.Modeles.Framework.Base;
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

        public static string CreateOrUpdate<TId>(IViewModel<TId> viewModel)
        {
            string code = (viewModel.Id.Equals(default(TId))) ? "ApplicationCategories.SysTranslation.Create" : "ApplicationCategories.SysTranslation.Update";
            return TranslationAssistant.Translate(code);
        }
    }
}
