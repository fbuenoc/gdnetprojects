using System.Collections.Generic;
using System.Web.Mvc;
using GDNET.FrameworkInfrastructure.WebServices;
using GDNET.Web.Extensions;

namespace GDNET.FrameworkInfrastructure.Common.Extensions
{
    public static class FrameworkJQueryAssistant
    {
        public static MvcHtmlString AutoCompleteSearchContent(this HtmlHelper htmlHelper)
        {
            return htmlHelper.AutoCompleteSearchContent(null);
        }

        public static MvcHtmlString AutoCompleteSearchContent(this HtmlHelper htmlHelper, object htmlAttributes)
        {
            List<string> listParams = new List<string>();
            listParams.Add(string.Format("{0}={1}", AppServiceConstant.Operator, AppServiceOperator.SearchContent));

            string targetUrl = "/AppServices.asmx/GetJsonResults";
            string parameters = string.Join("&", listParams.ToArray());

            return htmlHelper.AutoComplete(targetUrl, parameters, false, htmlAttributes);
        }
    }
}
