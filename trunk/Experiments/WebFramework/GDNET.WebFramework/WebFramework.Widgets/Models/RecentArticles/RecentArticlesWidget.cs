using System;
using WebFramework.Business.Common;
using WebFramework.Common.Widgets;
using WebFramework.Domain;

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
            base.AfterInstalled += RecentArticlesWidget_AfterInstalled;
            base.BeforeInstalled += RecentArticlesWidget_BeforeInstalled;
        }

        #region Events

        void RecentArticlesWidget_BeforeInstalled(object sender, EventArgs e)
        {
        }

        void RecentArticlesWidget_AfterInstalled(IWidget sender, WidgetEventArgs e)
        {
        }

        #endregion

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