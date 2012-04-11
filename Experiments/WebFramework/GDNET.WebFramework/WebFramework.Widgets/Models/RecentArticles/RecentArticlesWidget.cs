using System;
using WebFramework.Business.Common;
using WebFramework.Common.Widgets;
using WebFramework.Domain;
using WebFramework.Domain.Constants;

namespace WebFramework.Widgets.Models.RecentArticles
{
    public class RecentArticlesWidget : WidgetBase<RecentArticlesModel>
    {
        public override string Code
        {
            get { return "72CB2FED-5297-44F0-B37B-400782DC1E20"; }
        }

        public RecentArticlesWidget()
        {
            base.AfterInstalled += WidgetAfterInstalled;
            base.BeforeInstalled += WidgetBeforeInstalled;
        }

        #region Events

        void WidgetBeforeInstalled(object sender, EventArgs e)
        {
        }

        void WidgetAfterInstalled(IWidget sender, WidgetEventArgs e)
        {
        }

        #endregion

        protected override void RegisterProperties()
        {
            base.RegisterProperties();
            base.RegisterProperty(RecentArticlesConstants.ViewOption, ViewOption.WithDescription.ToString());
            base.RegisterProperty(WidgetBaseConstants.PropertyPageSize, WidgetBaseConstants.DefaultPageSize.ToString(), ListValueConstants.ContentDataTypes.NumberNormalNumber);
        }

        protected override RecentArticlesModel InitializeModel()
        {
            int pageSize = base.GetPropertyValue<int>(WidgetBaseConstants.PropertyPageSize);
            var listArticles = DomainRepositories.ContentItem.GetByContentType(typeof(Article), pageSize);

            RecentArticlesModel model = new RecentArticlesModel(base.region);
            model.InitializeArticles(listArticles);

            return model;
        }
    }
}