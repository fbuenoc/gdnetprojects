using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace GDNET.Web.Mvc.Helpers
{
    public static class ControllerAssistant
    {
        public static string GetControllerName(this Type controllerType)
        {
            return controllerType.Name.Replace("Controller", string.Empty);
        }

        public static string GetFullControllerName(this Type controllerType)
        {
            return controllerType.FullName;
        }

        public static string GetActionName(this LambdaExpression actionExpression)
        {
            return ((MethodCallExpression)actionExpression.Body).Method.Name;
        }

        public static string GetAreaName(this Controller controller)
        {
            if (controller.RouteData.DataTokens.Count > 0)
            {
                return (string)controller.RouteData.DataTokens["area"];
            }
            return string.Empty;
        }
    }
}
