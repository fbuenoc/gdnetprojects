﻿using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GDNET.FrameworkInfrastructure.Common.Handlers
{
    public class MultilingualMvcRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var language = requestContext.RouteData.Values["language"].ToString();
            var ci = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = ci;

            return base.GetHttpHandler(requestContext);
        }
    }
}
