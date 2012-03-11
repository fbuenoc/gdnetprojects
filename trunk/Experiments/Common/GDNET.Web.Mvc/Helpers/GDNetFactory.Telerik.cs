using Telerik.Web.Mvc.UI;

namespace GDNET.Web.Mvc.Helpers
{
    public partial class GDNetFactory
    {
        public string RegisterStyleSheet(string cssPath)
        {
            return this.htmlHelper.Telerik().StyleSheetRegistrar().DefaultGroup(ca => ca.Add(cssPath)).ToHtmlString();
        }

        public string RegisterScript(string scriptPath)
        {
            return this.htmlHelper.Telerik().ScriptRegistrar().Scripts(ca => ca.Add(scriptPath)).ToHtmlString();
        }
    }
}
