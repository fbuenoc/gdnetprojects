using System.Collections.Generic;
using System.Linq;
using WebFramework.Common.Framework.Common;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;
using WebFramework.Domain.Common;

namespace WebFramework.Widgets.Models.RecentArticles
{
    public class RecentArticlesModel : WidgetModelBase
    {
        public RecentArticlesModel(RegionModel regionModel)
            : base(regionModel)
        {
        }

        public IList<ContentItemModel> Articles
        {
            get;
            private set;
        }

        public void InitializeArticles(IList<ContentItem> articles)
        {
            this.Articles = articles.Select(x => new ContentItemModel(x)).ToList();
        }
    }
}