using System.Linq;
using GDNET.Web.Helpers;
using WebFramework.Common.Widgets;
using WebFramework.Domain;
using WebFramework.Domain.Constants;
using WebFramework.Domain.System;
using WebFramework.Widgets.ArticleWg.Constants;
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
            Region currentRegion = base.GetCurrentRegion();
            IArticleRepository articleRepository = DomainRepositories.GetWidgetRepository<IArticleRepository>(base.GetWidgetInfo());

            WidgetVisiblityMode visiblityMode = base.GetPropertyValue<WidgetVisiblityMode>(ArticleWidgetConstants.UIMode);
            ArticleWidgetModel model = base.InitializeModel();

            switch (visiblityMode)
            {
                case WidgetVisiblityMode.List:
                    var articlesModel = articleRepository.GetAllByRegion(currentRegion).Select(x => new ArticleModel(x)).ToList();
                    articlesModel.ForEach(x => model.ListArticles.Add(x));
                    break;

                case WidgetVisiblityMode.Single:
                    long? articleId = QueryStringAssistant.ParseInteger(ArticleWidgetConstants.ParameterNameArticleId);
                    if (articleId.HasValue)
                    {
                        var articleEntity = articleRepository.GetById(articleId.Value);
                        model.ListArticles.Add(new ArticleModel(articleEntity));
                    }
                    break;
            }

            return model;
        }

        public override string CurrentView
        {
            get
            {
                WidgetVisiblityMode visiblityMode = base.GetPropertyValue<WidgetVisiblityMode>(ArticleWidgetConstants.UIMode);
                switch (visiblityMode)
                {
                    case WidgetVisiblityMode.Single:
                        return "Single";

                    case WidgetVisiblityMode.List:
                        return "List";
                }

                return base.CurrentView;
            }
        }

        protected override void RegisterProperties()
        {
            base.RegisterProperties();

            this.RegisterProperty(ArticleWidgetConstants.UIMode, WidgetVisiblityMode.List.ToString());
            this.RegisterProperty(WidgetBaseConstants.ControllerNamespace, typeof(ListArticlesController).Namespace);
            this.RegisterProperty(string.Format(CommonConstants.WidgetPropertyRepositoryClassName, 0), typeof(ArticleRepository).FullName);
            this.RegisterProperty(string.Format(CommonConstants.WidgetPropertyRepositoryAssemblyName, 0), typeof(ArticleRepository).Assembly.GetName().Name);
        }
    }
}