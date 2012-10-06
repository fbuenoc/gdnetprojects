using System;
using System.Web.Mvc;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Common;
using GDNET.FrameworkInfrastructure.Common.Extensions;
using GDNET.FrameworkInfrastructure.Controllers.Base;
using GDNET.FrameworkInfrastructure.Controllers.Extensions;
using GDNET.FrameworkInfrastructure.Models.Content;
using GDNET.FrameworkInfrastructure.Models.PageModels;
using GDNET.FrameworkInfrastructure.Models.System;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Controllers
{
    public class HomeController : AbstractController
    {
        public ActionResult Index()
        {
            var listContentItems = DomainRepositories.ContentItem.GetTopWithActive(GlobalSettings.DefaultPageSize);
            var listItems = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(listContentItems, true);

            var focusItems = DomainRepositories.ContentItem.GetTopWithActiveByViews(GlobalSettings.FocusItemSize);
            var focusModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(focusItems, true);

            HomeIndexModel model = new HomeIndexModel()
            {
                NewItems = listItems,
                FocusItems = focusModels,
            };
            model.PageMeta.Description = "";
            model.PageMeta.Author = WebFrameworkServices.Translation.GetByKeyword("GUI.Common.SiteAuthor");
            model.PageMeta.Keywords = WebFrameworkServices.Translation.GetByKeyword("GUI.Page.Home.Keywords");

            return base.View(model);
        }

        public ActionResult Details(string id)
        {
            ContentItemModel contentModel = WebFrameworkServices.ContentModels.GetContentItemModel(id, true, true);
            if (contentModel == null)
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Index()));
            }

            var focusItems = DomainRepositories.ContentItem.GetTopWithActiveByViews(GlobalSettings.FocusItemSize, new Guid(id));
            var focusModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(focusItems, true);

            var authorModel = WebFrameworkServices.AccountModels.GetUserModelByEmail<UserDetailsModel>(contentModel.CreatedBy);
            authorModel.DisplayMode = UserDetailsMode.Default;

            HomeDetailModel model = new HomeDetailModel()
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
