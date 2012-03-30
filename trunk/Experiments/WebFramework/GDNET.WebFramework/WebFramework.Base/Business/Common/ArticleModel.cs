using WebFramework.Common.Business.Base;
using WebFramework.Business.Common;

namespace WebFramework.Common.Business.Common
{
    public class ArticleModel : ModelBusinessEntityBase<Article>
    {
        public ArticleModel(Article article)
            : base(article)
        {
        }
    }
}
