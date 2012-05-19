using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;

namespace WebFramework.Widgets.Domain.ArticleWg.Repositories
{
    public class ArticleRepository : AbstractRepository<Article, long>, IArticleRepository
    {
        public ArticleRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}