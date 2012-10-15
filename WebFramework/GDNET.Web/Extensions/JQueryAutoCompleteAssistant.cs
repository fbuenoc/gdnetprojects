using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using GDNET.Utils;

namespace GDNET.Web.Extensions
{
    public static class JQueryAutoCompleteAssistant
    {
        public static MvcHtmlString AutoComplete(HtmlHelper htmlHelper, string targetUrl, string parameters)
        {
            string logContainerId = GuidAssistant.NewId("log_");
            string logContainer = string.Format("<div id=\"{0}\"></div>", logContainerId);

            string containerId = GuidAssistant.NewId("autoc_");
            string textBox = htmlHelper.TextBox(containerId).ToString();

            string ajax = ReflectionAssistant.ReadFileContent(Assembly.GetExecutingAssembly(), "GDNET.Web.Extensions.ScriptTemplates.autoComplete.js");
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Cache), JQueryConstants.DefaultCache.ToString().ToLower());
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Timeout), JQueryConstants.DefaultTimeout.ToString());
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.MinLength), JQueryConstants.DefaultMinLength.ToString());
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Type), JQueryConstants.DefaultMethod.ToString());
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.ContentType), JQueryConstants.ContentTypeJson);
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Url), targetUrl);
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Id), containerId);
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Log), logContainerId);

            string data = "JSON.stringify({ params: '" + parameters + "', query: request.term })";
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Data), data);

            string documentReady = ReflectionAssistant.ReadFileContent(Assembly.GetExecutingAssembly(), "GDNET.Web.Extensions.ScriptTemplates.ready.js");
            documentReady = documentReady.Replace(JQueryAssistant.GetPattern(JQueryConstants.Body), ajax);

            return MvcHtmlString.Create(string.Concat(logContainer, textBox, documentReady));
        }
    }
}
