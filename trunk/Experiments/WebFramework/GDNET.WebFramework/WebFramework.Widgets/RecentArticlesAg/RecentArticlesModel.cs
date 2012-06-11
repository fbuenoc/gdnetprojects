using System.Collections.Generic;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;
using WebFramework.Widgets.ArticleWg.Models;

namespace WebFramework.Widgets.RecentArticlesAg
{
    public class RecentArticlesModel : WidgetModelBase
    {
        private IList<ArticleModel> listArticles = new List<ArticleModel>();

        public RecentArticlesModel(RegionModel regionModel)
            : base(regionModel)
        {
        }

        public IList<ArticleModel> ListArticles
        {
            get { return this.listArticles; }
        }
    }
}