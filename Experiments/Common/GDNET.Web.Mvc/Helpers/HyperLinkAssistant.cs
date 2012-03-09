using System.Web.Mvc;
using System.Web.Routing;

namespace GDNET.Web.Mvc.Helpers
{
    public static class HyperLinkAssistant
    {
        public static string SimpleLink(this HtmlHelper html, string url, string text)
        {
            return html.SimpleLink(url, text, string.Empty);
        }

        public static string SimpleLink(this HtmlHelper html, string url, string text, string title)
        {
            return html.HtmlLink(url, text, new { title = title }).ToHtmlString();
        }

        public static MvcHtmlString HtmlLink(this HtmlHelper html, string url, string text, object htmlAttributes)
        {
            TagBuilder tb = new TagBuilder("a");
            tb.InnerHtml = text;
            tb.MergeAttribute("href", url);

            if (htmlAttributes != null)
            {
                tb.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }

            return MvcHtmlString.Create(tb.ToString(TagRenderMode.Normal));
        }

    }
}
