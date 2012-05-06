using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Widgets.ArticleWg.Domain;

namespace WebFramework.Widgets.ArticleWg.Repositories
{
    public class ArticleRepository : AbstractRepository<Article, long>, IArticleRepository
    {
        public ArticleRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}