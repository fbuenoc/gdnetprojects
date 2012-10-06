using System;
using System.Web.Mvc;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Common.Extensions;
using GDNET.FrameworkInfrastructure.Controllers.Base;
using GDNET.FrameworkInfrastructure.Models.Content;
using GDNET.FrameworkInfrastructure.Models.HomeModels;
using GDNET.FrameworkInfrastructure.Models.System;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Controllers
{
    public class HomeController : AbstractController
    {
        private const int DefaultPageSize = 10;
        private const int FocusItemSize = 10;

        public ActionResult Index()
        {
            var listContentItems = DomainRepositories.ContentItem.GetTopWithActive(DefaultPageSize);
            var listItems = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(listContentItems, true);

            var focusItems = DomainRepositories.ContentItem.GetTopWithActiveByViews(FocusItemSize);
            var focusModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(focusItems, true);

            IndexModel model = new IndexModel()
            {
                NewItems = listItems,
                FocusItems = focusModels,
            };
            model.PageMeta.Description = "";
            model.PageMeta.Author = "";
            model.PageMeta.Keywords = "Learn ASP.NET, Learn ASP.NET MVC, Learn JavaScript, Learn JQuery, Design Pattern best practice";

            return base.View(model);
        }

        public ActionResult Details(string id)
        {
            ContentItemModel contentModel = WebFrameworkServices.ContentModels.GetContentItemModel(id, true, true);
            if (contentModel == null)
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Index()));
            }

            var focusItems = DomainRepositories.ContentItem.GetTopWithActiveByViews(FocusItemSize, new Guid(id));
            var focusModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(focusItems, true);

            var authorModel = WebFrameworkServices.AccountModels.GetUserModelByEmail<UserDetailsModel>(contentModel.CreatedBy);

            DetailModel model = new DetailModel()
            {
                ItemModel = contentModel,
                FocusItems = focusModels,
                AuthorModel = authorModel
            };
            model.PageMeta.Keywords = contentModel.Keywords;
            model.PageMeta.Description = contentModel.Description;
            model.PageMeta.Author = authorModel.DisplayName;

            return base.View(model);
        }

        public ActionResult About()
        {
            return base.View();
        }
    }
}
