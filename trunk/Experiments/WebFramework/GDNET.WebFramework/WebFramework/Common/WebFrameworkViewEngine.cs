using System.Web.Mvc;

namespace WebFramework.Common
{
    public sealed class WebFrameworkViewEngine : WebFormViewEngine
    {
        public WebFrameworkViewEngine()
        {
            var viewLocations = new[] {  
                "~/Views/{1}/{0}.aspx",  
                "~/Views/{1}/{0}.ascx",  
                "~/Views/Shared/{0}.aspx",  
                "~/Views/Shared/{0}.ascx",  
                "~/Views/Widgets/{0}.aspx",
                "~/Views/Widgets/{0}.ascx"
            };

            this.PartialViewLocationFormats = viewLocations;
            this.ViewLocationFormats = viewLocations;
        }
    }
}