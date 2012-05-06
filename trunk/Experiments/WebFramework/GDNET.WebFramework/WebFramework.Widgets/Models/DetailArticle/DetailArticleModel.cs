using WebFramework.Business.Common;
using WebFramework.Business.Helpers;
using WebFramework.Common.Business.Common;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;
using WebFramework.Domain.Common;

namespace WebFramework.Widgets.Models.DetailArticle
{
    public class DetailArticleModel : WidgetModelBase
    {
        public DetailArticleModel(RegionModel region)
            : base(region)
        {
        }

        public ArticleModel ItemModel
        {
            get;
            private set;
        }

        public void InitializeModel(ContentItem itemEntity)
        {
            //if (itemEntity != null)
            //{
            //    Article myArticle = BusinessEntityAssistant.BuildEntity<Article>(itemEntity);
            //    this.ItemModel = new ArticleModel(myArticle);
            //}
        }
    }
}