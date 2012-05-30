using System.Linq;
using WebFramework.Common.Widgets;
using WebFramework.Domain;
using WebFramework.Domain.Constants;
using WebFramework.Domain.System;
using WebFramework.Widgets.ArticleWg.Controllers;
using WebFramework.Widgets.ArticleWg.Models;
using WebFramework.Widgets.Domain.ArticleWg.Repositories;

namespace WebFramework.Widgets.ArticleWg
{
    public class ArticleWidget : WidgetBase<ArticleWidgetModel>
    {
        public override string Code
        {
            get { return "6699A437-E1FE-4006-9457-177D40F2EA69"; }
        }

        protected override ArticleWidgetModel InitializeModel()
        {
            ArticleWidgetModel model = base.InitializeModel();

            Region currentRegion = base.GetCurrentRegion();
            IArticleRepository articleRepository = DomainRepositories.GetWidgetRepository<IArticleRepository>(base.GetWidgetInfo());

            var articlesModel = articleRepository.GetAllByRegion(currentRegion).Select(x => new ArticleModel(x)).ToList();
            articlesModel.ForEach(x => model.ListArticles.Add(x));

            return model;
        }

        protected override void RegisterProperties()
        {
            base.RegisterProperties();

            this.RegisterProperty(WidgetBaseConstants.PropertyUsageTemplate, WidgetBaseConstants.DefaultPageSize.ToString());
            this.RegisterProperty(WidgetBaseConstants.ControllerNamespace, typeof(ListArticlesController).Namespace);
            this.RegisterProperty(string.Format(CommonConstants.WidgetPropertyRepositoryClassName, 0), typeof(ArticleRepository).FullName);
            this.RegisterProperty(string.Format(CommonConstants.WidgetPropertyRepositoryAssemblyName, 0), typeof(ArticleRepository).Assembly.GetName().Name);
        }
    }
}