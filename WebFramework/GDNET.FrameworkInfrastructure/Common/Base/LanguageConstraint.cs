using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

namespace GDNET.FrameworkInfrastructure.Common.Base
{
    public class LanguageConstraint : IRouteConstraint
    {
        private List<string> values = new List<string>() { "en", "vi" };

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string aValue = values[parameterName].ToString();
            return this.values.Contains(aValue);
        }
    }
}
