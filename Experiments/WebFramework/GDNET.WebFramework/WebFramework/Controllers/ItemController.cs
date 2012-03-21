using System.Web.Mvc;
using GDNET.Extensions;
using WebFramework.Base.Framework.Common;
using WebFramework.Business.Common;
using WebFramework.Common.Controllers;
using WebFramework.Domain;
using WebFramework.Domain.Common;
using WebFramework.ViewModels;

namespace WebFramework.Controllers
{
    public sealed class ItemController : AbstractController
    {
        public ActionResult Details(string id)
        {
            var viewModel = new ItemViewModel();
            long itemId = id.ToLong();

            var contentItem = DomainRepositories.ContentItem.GetById(itemId);
            if (contentItem != null)
            {
                viewModel.Item = new ContentItemModel(contentItem);
                string viewName = this.GetViewName(contentItem);

                return base.View(viewName, viewModel);
            }
            else
            {
                return base.View(viewModel);
            }
        }

        private string GetViewName(ContentItem contentItem)
        {
            string viewName = "Details";
            string typeName = contentItem.ContentType.TypeName;

            if (typeName == typeof(Product).GetQualifiedTypeName())
            {
                viewName = "ProductDetails";
            }
            else if (typeName == typeof(Article).GetQualifiedTypeName())
            {
                viewName = "ArticleDetails";
            }
            else if (typeName == typeof(Comment).GetQualifiedTypeName())
            {
                viewName = "CommentDetails";
            }

            return viewName;
        }
    }
}
