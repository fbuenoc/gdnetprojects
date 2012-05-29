﻿using System.Collections.Generic;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;
using WebFramework.Widgets.ArticleWg.Models;

namespace WebFramework.Widgets.ArticleWg
{
    public class ArticleWidgetModel : WidgetModelBase
    {
        private IList<ArticleModel> listArticles = new List<ArticleModel>();

        public ArticleWidgetModel(RegionModel regionModel)
            : base(regionModel)
        {
        }

        public IList<ArticleModel> ListArticles
        {
            get { return this.listArticles; }
        }
    }
}