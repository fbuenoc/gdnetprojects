using System;
using System.Web.Mvc;
using WebFramework.Common.Widgets.Controllers;

namespace WebFramework.Widgets.ArticleWg.Controllers
{
    public class ListArticlesController : AbstractWidgetListCrudController<ArticleModel>
    {
        public override ActionResult List()
        {
            return base.View("Article.ListArticles");
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
