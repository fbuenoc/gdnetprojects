using System.Web.Mvc;
using WebFramework.UI.Helpers;
using WebFramework.UI.Translations;
using WebFramework.UI.Widgets;

namespace WebFramework.UI.Common
{
    public class WebFrameworkFactory
    {
        private HtmlHelper htmlHelper;

        public WebFrameworkFactory(HtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        public WidgetHanlder WidgetHanlder()
        {
            return new WidgetHanlder(this.htmlHelper);
        }

        public ActionLinkFactory ActionLink()
        {
            return new ActionLinkFactory(this.htmlHelper);
        }

        public NumberFormatAssistant NumberFormat()
        {
            return new NumberFormatAssistant();
        }

        public HyperLinkAssistant HyperLink()
        {
            return new HyperLinkAssistant(this.htmlHelper);
        }

        public TranslationFactory Translation()
        {
            return new TranslationFactory();
        }

        public SystemTranslation SystemTranslation()
        {
            return new SystemTranslation();
        }

        public TextEditorFactory TextEditor()
        {
            return new TextEditorFactory(this.htmlHelper);
        }
    }

}