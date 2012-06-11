using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using WebFramework.Common.Controllers;
using WebFramework.Common.Security;
using WebFramework.Domain;
using WebFramework.Widgets.ArticleWg.Models;
using WebFramework.Widgets.Domain.ArticleWg;
using WebFramework.Widgets.Domain.ArticleWg.Repositories;

namespace WebFramework.Widgets.ArticleWg.Controllers
{
    public class ListArticlesController : AbstractListCrudController<ArticleModel>, IRequiredManagerController
    {
        private IArticleRepository articleRepository = null;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.articleRepository = DomainRepositories.GetWidgetRepository<ArticleRepository>(base.CurrentWidget);
        }

        public override ActionResult List()
        {
            var articles = this.articleRepository.GetAll().Select(x => new ArticleModel(x)).ToList();
            return base.View(articles);
        }

        protected override object OnCreateExecuting(ArticleModel model, FormCollection collection)
        {
            Article newArticle = Article.Factory.Create(model.Title, model.Description, model.FullContent);
            var result = this.articleRepository.Save(newArticle);
            return result ? (object)newArticle.Id : null;
        }

        protected override bool OnDeleteExecuting(ArticleModel model, FormCollection collection)
        {
            return this.articleRepository.Delete(model.Id);
        }

        protected override bool OnEditExecuting(ArticleModel model, FormCollection collection)
        {
            var article = this.articleRepository.GetById(model.Id);
            article.Title = model.Title;
            article.Description = model.Description;
            article.FullContent = model.FullContent;

            return this.articleRepository.Update(article);
        }

        protected override ArticleModel OnDetailsChecking(string id)
        {
            long articleId = long.Parse(id);
            var article = this.articleRepository.GetById(articleId);
            return new ArticleModel(article);
        }
    }
}
