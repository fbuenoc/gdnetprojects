using System.Collections.Generic;
using System.Web.Mvc;

namespace WebFramework.Common.Base
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
                "~/Views/Widgets/{0}.aspx",
                "~/Views/Widgets/Shared/{0}.ascx",
            };

            this.PartialViewLocationFormats = viewLocations.ToArray();
            this.ViewLocationFormats = viewLocations.ToArray();
        }
    }
}