using System.Web.Mvc;
using System.Web.Routing;

namespace GDNET.Web.Mvc.Helpers
{
    public partial class GDNetFactory
    {
        public MvcHtmlString HtmlLink(string url, string linkText)
        {
            return this.HtmlLink(url, linkText, string.Empty);
        }

        public MvcHtmlString HtmlLink(string url, string text, string titleText)
        {
            return this.HtmlLink(url, text, new { title = titleText });
        }

        public MvcHtmlString HtmlLink(string url, string text, object htmlAttributes)
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
