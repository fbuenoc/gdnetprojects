using System.Reflection;
using System.Web.Mvc;
using GDNET.Utils;

namespace GDNET.Web.Extensions
{
    public static class JQueryAjaxAssistant
    {
        private const int DefaultTimeout = 10000;
        private const HttpMethod DefaultMethod = HttpMethod.POST;
        private const bool DefaultCache = false;

        public static MvcHtmlString Ajax(this HtmlHelper htmlHelper, string targetUrl)
        {
            string containerId = GuidAssistant.NewId("ajax_");
            string container = string.Format("<div id=\"{0}\"></div>", containerId);

            string ajax = ReflectionAssistant.ReadFileContent(Assembly.GetExecutingAssembly(), "GDNET.Web.Extensions.ScriptTemplates.ajaxWSString.js");
            ajax = ajax.Replace(GetPattern(JQueryConstants.Cache), DefaultCache.ToString().ToLower());
            ajax = ajax.Replace(GetPattern(JQueryConstants.Timeout), DefaultTimeout.ToString());
            ajax = ajax.Replace(GetPattern(JQueryConstants.Type), DefaultMethod.ToString());
            ajax = ajax.Replace(GetPattern(JQueryConstants.Url), targetUrl);
            ajax = ajax.Replace(GetPattern(JQueryConstants.Data), "{}");
            ajax = ajax.Replace(GetPattern(JQueryConstants.Id), containerId);

            string documentReady = ReflectionAssistant.ReadFileContent(Assembly.GetExecutingAssembly(), "GDNET.Web.Extensions.ScriptTemplates.ready.js");
            documentReady = documentReady.Replace(GetPattern(JQueryConstants.Body), ajax);

            return MvcHtmlString.Create(string.Concat(container, documentReady));
        }

        private static string GetPattern(string param)
        {
            return "__" + param;
        }
    }
}
