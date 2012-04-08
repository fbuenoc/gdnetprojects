using System.Web.Mvc;
using Telerik.Web.Mvc.UI;
using System.Linq.Expressions;
using System;
using GDNET.Common.Helpers;

namespace WebFramework.UI.Helpers
{
    public sealed class AutoCompleteWS : ComponentFactoryBase
    {
        public AutoCompleteWS(HtmlHelper html)
            : base(html)
        {
        }

        public void Create(string componentName, ServicesType service, bool enable)
        {
            var component = base.html.Telerik().AutoComplete().Name(componentName);
            component.AutoFill(false).HighlightFirstMatch(true);
            component.Filterable(filter => filter.FilterMode(AutoCompleteFilterMode.Contains));
            component.DataBinding(binding => binding.WebService().Select(this.GetWebServicePath(service)));
            component.Enable(enable);

            component.Render();
        }
    }
}
