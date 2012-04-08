using System.Web.Mvc;
using Telerik.Web.Mvc.UI;

namespace WebFramework.UI.Helpers
{
    public sealed class ComboBoxWS : ComponentFactoryBase
    {
        public ComboBoxWS(HtmlHelper html)
            : base(html)
        {
        }

        public void Create(string componentName, ServicesType service, bool enable)
        {
            var component = this.html.Telerik().ComboBox().Name(componentName);
            component.DataBinding(binding => binding.WebService().Select(base.GetWebServicePath(service)));
            component.Enable(enable).Filterable();
            component.HighlightFirstMatch(true).AutoFill(false);

            component.Render();
        }
    }
}
