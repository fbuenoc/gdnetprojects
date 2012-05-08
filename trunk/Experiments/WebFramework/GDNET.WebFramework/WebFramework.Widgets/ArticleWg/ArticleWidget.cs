using System;
using WebFramework.Common.Widgets;
using WebFramework.Widgets.ArticleWg.Controllers;
using WebFramework.Widgets.ArticleWg.Repositories;

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
            ArticleWidgetModel model = new ArticleWidgetModel(base.region);
            return model;
        }

        public ArticleWidget()
            : base()
        {
            base.BeforeInstalled += WidgetBeforeInstalled;
            base.AfterInstalled += WidgetAfterInstalled;
        }

        #region Events

        void WidgetBeforeInstalled(object sender, EventArgs e)
        {
        }

        void WidgetAfterInstalled(IWidget sender, WidgetEventArgs e)
        {
            e.Instance.RepositoryAssemblyName = typeof(ArticleRepository).Assembly.GetName().Name;
            e.Instance.RepositoryClassName = typeof(ArticleRepository).FullName;
        }

        #endregion

        protected override void RegisterProperties()
        {
            base.RegisterProperties();

            this.RegisterProperty(WidgetBaseConstants.PropertyUsageTemplate, WidgetBaseConstants.DefaultPageSize.ToString());
            this.RegisterProperty(WidgetBaseConstants.ControllerNamespace, typeof(ListArticlesController).Namespace);
        }
    }
}