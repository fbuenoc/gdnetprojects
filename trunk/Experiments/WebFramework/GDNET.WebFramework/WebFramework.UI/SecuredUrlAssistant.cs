using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using GDNET.Web.Mvc.Helpers;

namespace WebFramework.UI
{
    public static class SecuredUrlAssistant
    {
        public static string Action<TController>(this UrlHelper urlHelper, Expression<Func<TController, object>> actionExpression) where TController : Controller
        {
            return urlHelper.Action(actionExpression, null);
        }

        public static string Action<TController>(this UrlHelper urlHelper, Expression<Func<TController, object>> actionExpression, object values) where TController : Controller
        {
            var fullControllerName = typeof(TController).GetFullControllerName();
            var actionName = actionExpression.GetActionName();

            if ((new SecurityAssistant()).ActionIsAllowedForUser(fullControllerName, actionName) == false)
            {
                return string.Empty;
            }

            var controllerName = typeof(TController).GetControllerName();
            return urlHelper.Action(actionName, controllerName, values);
        }

        public static string AreaAction<TController>(this UrlHelper urlHelper, Expression<Func<TController, object>> actionExpression, string areaName) where TController : Controller
        {
            var fullControllerName = typeof(TController).GetFullControllerName();
            var actionName = actionExpression.GetActionName();

            if ((new SecurityAssistant()).ActionIsAllowedForUser(fullControllerName, actionName) == false)
            {
                return string.Empty;
            }

            var controllerName = typeof(TController).GetControllerName();
            var routeValueDictionary = new RouteValueDictionary { { "area", areaName } };
            return urlHelper.Action(actionName, controllerName, routeValueDictionary);
        }
    }
}