using System.Text;
using System.Web;
using System.Web.Mvc.Html;
using GDNET.Extensions;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Base.Common;
using WebFramework.Base.Framework.Common;

namespace WebFramework.Base.Helpers
{
    public enum Actions
    {
        DetailEdit,
        All,
    }

    public partial class WebFrameworkFactory
    {
        public string HyperLink(ContentItemModel itemModel)
        {
            var htmlAttributes = new
            {
                title = itemModel.Description.StripTagsRegex()
            };

            return this.HyperLink(itemModel, htmlAttributes);
        }

        public string HyperLink(ContentItemModel itemModel, object htmlAttributes)
        {
            string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
            string rootUrl = absoluteUri.Substring(0, absoluteUri.IndexOf("/", absoluteUri.IndexOf("//")));

            string itemUrl = string.Format("/Item/Details/{0}", itemModel.Id);
            string newUrl = string.Format("{0}{1}", rootUrl, itemUrl);
            newUrl = FrameworkServices.Navigation.AddReturnUrl(newUrl);

            return this.htmlHelper.GDNet().HtmlLink(newUrl, itemModel.Name, htmlAttributes).ToHtmlString();
        }

        public string HyperLinkActions(object routeValues)
        {
            return this.HyperLinkActions(routeValues, Actions.All);
        }

        public string HyperLinkActions(object routeValues, Actions action)
        {
            StringBuilder sb = new StringBuilder();

            if (action == Actions.All || action == Actions.DetailEdit)
            {
                string detail = this.htmlHelper.ActionLink("Details", "Details", routeValues).ToString();
                sb.AppendFormat("{0} | ", detail);
            }

            if (action == Actions.All || action == Actions.DetailEdit)
            {
                string edit = this.htmlHelper.ActionLink("Edit", "Edit", routeValues).ToString();
                sb.AppendFormat("{0} | ", edit);
            }

            if (action == Actions.All)
            {
                string delete = this.htmlHelper.ActionLink("Delete", "Delete", routeValues).ToString();
                sb.AppendFormat("{0} | ", delete);
            }

            return (sb.Length > 0) ? sb.ToString().Substring(0, sb.Length - 3) : string.Empty;
        }
    }
}
