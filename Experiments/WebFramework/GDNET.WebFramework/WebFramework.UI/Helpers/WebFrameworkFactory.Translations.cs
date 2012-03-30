using WebFramework.Common.Framework.Base;
using WebFramework.Domain;
using WebFramework.UI.Translations;

namespace WebFramework.UI.Helpers
{
    public partial class WebFrameworkFactory
    {
        public string Translate(string codeText)
        {
            return DomainServices.Translation.Translate(codeText);
        }

        public string CreateOrUpdate<TId>(IViewModel<TId> viewModel)
        {
            string code = (viewModel.Id.Equals(default(TId))) ? "SysTranslation.Create" : "SysTranslation.Update";
            return this.Translate(code);
        }

        public SystemTranslation SysTranslations()
        {
            return new SystemTranslation();
        }
    }
}
