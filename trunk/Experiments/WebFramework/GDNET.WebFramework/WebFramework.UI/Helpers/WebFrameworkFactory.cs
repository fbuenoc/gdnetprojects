using System.Web.Mvc;
using WebFramework.Base.Framework.Base;
using WebFramework.Domain;
using WebFramework.UI.Widgets;

namespace WebFramework.UI.Helpers
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
            return DomainServices.Translation.Translate(codeText);
        }

        public string CreateOrUpdate<TId>(IViewModel<TId> viewModel)
        {
            string code = (viewModel.Id.Equals(default(TId))) ? "SysTranslation.Create" : "SysTranslation.Update";
            return this.Translate(code);
        }

        public WidgetHanlder WidgetHanlder
        {
            get { return new WidgetHanlder(this.htmlHelper); }
        }
    }
}