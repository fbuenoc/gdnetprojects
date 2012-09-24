using System;
using System.Web.Mvc;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Common.Extensions;
using GDNET.FrameworkInfrastructure.Controllers.Base;
using GDNET.FrameworkInfrastructure.Models.Content;
using GDNET.FrameworkInfrastructure.Models.SearchModels;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Controllers
{
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
            var author = DomainRepositories.User.GetById(new Guid(authorId));
            var authorModel = WebFrameworkServices.AccountModels.GetUpdateDetailsModel(author);

            var topItems = DomainRepositories.ContentItem.GetTopWithActiveByAuthor(DefaultPageSize, author.Email);
            var topModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(topItems, true);

            var focusItems = DomainRepositories.ContentItem.GetTopWithActiveByViews(FocusItemSize);
            var focusModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(focusItems, true);

            SearchByAuthorModel model = new SearchByAuthorModel(SearchMode.Author)
            {
                NewItems = topModels,
                FocusItems = focusModels,
                AuthorModel = authorModel,
            };
            model.PageMeta.Description = string.Format(WebFrameworkServices.Translation.GetByKeyword("GUI.Search.ByAuthor.Description"), authorModel.DisplayName);
            model.PageMeta.Author = authorModel.DisplayName;

            return base.View("SearchByAuthor", model);
        }
    }
}
