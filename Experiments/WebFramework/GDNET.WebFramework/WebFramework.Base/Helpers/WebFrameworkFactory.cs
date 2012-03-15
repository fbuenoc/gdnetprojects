using System.Web.Mvc;
using WebFramework.Base.Framework.Base;
using WebFramework.Domain.DefaultImpl;

namespace WebFramework.Base.Helpers
{
    public partial class WebFrameworkFactory
    {
        private HtmlHelper htmlHelper;

        public WebFrameworkFactory(HtmlHelper html)
        {
            this.htmlHelper = html;
        }

        public string Translate(string codeText)
        {
            var defaultCulture = DomainRepositories.Culture.GetDefault();

            if (string.IsNullOrEmpty(codeText))
            {
                return string.Empty;
            }

            var translation = DomainRepositories.Translation.GetByCode(codeText, defaultCulture);
            return (translation == null) ? string.Format("!{0}!", codeText) : translation.Value;
        }

        public string CreateOrUpdate<TId>(IViewModel<TId> viewModel)
        {
            string code = (viewModel.Id.Equals(default(TId))) ? "SysTranslation.Create" : "SysTranslation.Update";
            return this.Translate(code);
        }
    }
}
