using WebFramework.Base.Business.Base;
using WebFramework.Business.Common;

namespace WebFramework.Base.Business.Common
{
    public class ArticleModel : ModelBusinessEntityBase<Article>
    {
        public ArticleModel(Article article)
            : base(article)
        {
        }
    }
}
