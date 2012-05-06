using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebFramework.Common.Widgets;
using WebFramework.Domain;

namespace WebFramework.NHibernate
{
    public sealed class WebFrameworkViewEngine : WebFormViewEngine
    {
        public WebFrameworkViewEngine()
        {
            List<string> viewLocations = new List<string>()
            {
                "~/Views/{1}/{0}.aspx",  
                "~/Views/{1}/{0}.ascx",  
                "~/Views/Shared/{0}.ascx",  
                "~/Views/Widgets/{0}.ascx",
                "~/Views/Widgets/Shared/{0}.ascx"
            };

            // Route for all widgets
            foreach (var widget in DomainRepositories.Widget.GetAll())
            {
                var templateProperty = widget.Properties.FirstOrDefault(x => x.Code == WidgetBaseConstants.PropertyUsageTemplate);
                if (templateProperty != null)
                {
                    viewLocations.Add(string.Format("~/Views/Widgets/{0}/{1}/{{0}}.ascx", widget.TechnicalName, templateProperty.Value));
                }
            }

            this.PartialViewLocationFormats = viewLocations.ToArray();
            this.ViewLocationFormats = viewLocations.ToArray();
        }
    }
}