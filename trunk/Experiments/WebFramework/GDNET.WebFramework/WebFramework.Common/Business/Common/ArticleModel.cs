using System;
using WebFramework.Business.Common;
using WebFramework.Common.Business.Base;

namespace WebFramework.Common.Business.Common
{
    public class ArticleModel : ModelBusinessEntityBase<Article>
    {
        public ArticleModel(Article article)
            : base(article)
        {
            this.MainContent = article.MainContent;
            this.PublishedDate = article.PublishedDate;
        }

        public string MainContent
        {
            get;
            private set;
        }

        public DateTime PublishedDate
        {
            get;
            private set;
        }
    }
}
