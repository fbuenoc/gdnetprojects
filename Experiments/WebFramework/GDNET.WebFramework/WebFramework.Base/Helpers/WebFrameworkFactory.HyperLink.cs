using System.Web;
using GDNET.Extensions;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Base.Common;
using WebFramework.Base.Framework.Common;

namespace WebFramework.Base.Helpers
{
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
    }
}
