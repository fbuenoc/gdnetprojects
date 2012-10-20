using System;
using System.Web.Mvc;
using GDNET.AOP.ExceptionHandling;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Common.Extensions;
using GDNET.FrameworkInfrastructure.Controllers.Base;
using GDNET.FrameworkInfrastructure.Models.Content;
using GDNET.FrameworkInfrastructure.Models.PageModels;
using GDNET.FrameworkInfrastructure.Models.System;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Controllers
{
    [CaptureException]
    public class SearchController : AbstractController
    {
        private const int DefaultPageSize = 10;
        private const int FocusItemSize = 10;
        private const string SearchBy = "by";
        private const string SearchValue = "value";
        private const string SearchAuthor = "author";

        public ActionResult Index()
        {
            string searchBy = base.Request.Params[SearchBy];

            switch (searchBy)
            {
                case SearchAuthor:
                    return this.SearchByAuthor();
                default:
                    return base.RedirectToAction("Index", "Home");
            }
        }

        private ActionResult SearchByAuthor()
        {
            string authorId = base.Request.Params[SearchValue];
            Guid guid = Guid.Empty;
            SearchByAuthorModel model = new SearchByAuthorModel(SearchMode.Author);

            if (Guid.TryParse(authorId, out guid))
            {
                var author = DomainRepositories.User.GetById(guid);
                var authorModel = WebFrameworkServices.AccountModels.GetUserModel<UserDetailsModel>(author);
                authorModel.DisplayMode = UserDetailsMode.Search;

                var topItems = DomainRepositories.ContentItem.GetTopWithActiveByAuthor(DefaultPageSize, author.Email);
                var topModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(topItems, true);

                var focusItems = DomainRepositories.ContentItem.GetTopWithActiveByViews(FocusItemSize);
                var focusModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(focusItems, true);

                model.NewItems = topModels;
                model.FocusItems = focusModels;
                model.AuthorModel = authorModel;
                model.PageMeta.Description = string.Format(WebFrameworkServices.Translation.GetByKeyword("GUI.Search.ByAuthor.Description"), authorModel.DisplayName);
                model.PageMeta.Author = authorModel.DisplayName;
            }

            return base.View("SearchByAuthor", model);
        }
    }
}
