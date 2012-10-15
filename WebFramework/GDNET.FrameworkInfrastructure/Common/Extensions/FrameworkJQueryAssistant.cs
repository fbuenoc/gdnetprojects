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
            List<string> listParams = new List<string>();
            listParams.Add(string.Format("{0}={1}", AppServiceConstant.Operator, AppServiceOperator.SearchContent));

            string targetUrl = "/AppServices.asmx/GetJsonResults";
            string parameters = string.Join("&", listParams.ToArray());

            return JQueryAutoCompleteAssistant.AutoComplete(htmlHelper, targetUrl, parameters);
        }
    }
}
