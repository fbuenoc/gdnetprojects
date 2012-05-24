using WebFramework.Common.Framework.Base;
using WebFramework.Widgets.Domain.ArticleWg;

namespace WebFramework.Widgets.ArticleWg.Models
{
    public class ArticleModel : ModelEntityBase<Article, long>
    {
        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string FullContent
        {
            get;
            set;
        }

        public ArticleModel()
            : base()
        {
        }

        public ArticleModel(Article entity)
            : base(entity)
        {
        }
    }
}