using System.IO;
using System.Web;
using System.Web.Mvc;
using GDNET.Extensions;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Base.Framework.Common;

namespace WebFramework.Base.Helpers
{
    public static class NavigationAssistant
    {
        public static string HyperLink(this HtmlHelper html, ContentItemModel itemModel)
        {
            var htmlAttributes = new
            {
                title = itemModel.Description.StripTagsRegex()
            };

            return html.HyperLink(itemModel, htmlAttributes);
        }

        public static string HyperLink(this HtmlHelper html, ContentItemModel itemModel, object htmlAttributes)
        {
            string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
            string rootUrl = absoluteUri.Substring(0, absoluteUri.IndexOf("/", absoluteUri.IndexOf("//")));

            string url = string.Format("/Item/Details/{0}", itemModel.Id);
            string newUrl = Path.Combine(rootUrl, url);

            return html.HtmlLink(newUrl, itemModel.Name, htmlAttributes).ToHtmlString();
        }
    }
}
