using System;
using System.Web.Mvc;
using WebFramework.Common.Widgets.Controllers;
using WebFramework.Domain;
using WebFramework.Widgets.ArticleWg.Models;
using WebFramework.Widgets.Domain.ArticleWg.Repositories;

namespace WebFramework.Widgets.ArticleWg.Controllers
{
    public class ListArticlesController : AbstractWidgetListCrudController<ArticleModel>
    {
        public override ActionResult List()
        {
            IArticleRepository articleRepository = DomainRepositories.GetWidgetRepository<ArticleRepository>(base.CurrentWidget);

            return base.View();
        }

        protected override object OnCreateExecuting(ArticleModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override bool OnDeleteExecuting(ArticleModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override bool OnEditExecuting(ArticleModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }
    }
}
