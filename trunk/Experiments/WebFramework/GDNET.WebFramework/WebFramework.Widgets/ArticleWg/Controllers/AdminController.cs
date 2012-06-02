using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using WebFramework.Common.Constants;
using WebFramework.Common.Controllers;
using WebFramework.Domain;
using WebFramework.Extensions;
using WebFramework.Widgets.ArticleWg.Models;
using WebFramework.Widgets.Domain.ArticleWg;
using WebFramework.Widgets.Domain.ArticleWg.Repositories;

namespace WebFramework.Widgets.ArticleWg.Controllers
{
    public class AdminController : AbstractListCrudController<ArticleModel>
    {
        private IArticleRepository articleRepository = null;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            this.articleRepository = DomainRepositories.GetWidgetRepository<IArticleRepository>(base.CurrentWidget);
        }

        public override ActionResult Index()
        {
            var objet = new
            {
                zid = this.HttpContext.Request.QueryString[QueryStringConstants.ZoneId],
                rid = this.HttpContext.Request.QueryString[QueryStringConstants.RegionId],
            };
            return base.RedirectToAction(ActionList, objet);
        }

        public override ActionResult List()
        {
            IList<ArticleModel> listeArticles = null;

            var region = ControllerAssistant.GetCurrentRegion();
            if (region == null)
            {
                listeArticles = this.articleRepository.GetAll().Select(x => new ArticleModel(x)).ToList();
            }
            else
            {
                listeArticles = this.articleRepository.GetAllByRegion(region).Select(x => new ArticleModel(x)).ToList();
            }

            return base.View(listeArticles);
        }

        protected override object OnCreateExecuting(ArticleModel model, FormCollection collection)
        {
            var region = ControllerAssistant.GetCurrentRegion();
            if (region != null)
            {
                Article newArticle = Article.Factory.Create(model.Title, model.Description, model.FullContent);
                newArticle.AddRegion(region);

                var result = this.articleRepository.Save(newArticle);
                if (result)
                {
                    return newArticle.Id;
                }
            }

            return null;
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
