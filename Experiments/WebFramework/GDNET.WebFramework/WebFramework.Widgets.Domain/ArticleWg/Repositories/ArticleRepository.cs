using System.Collections.Generic;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Domain.System;

namespace WebFramework.Widgets.Domain.ArticleWg.Repositories
{
    public class ArticleRepository : AbstractRepository<Article, long>, IArticleRepository
    {
        public ArticleRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        public IList<Article> GetAllByRegion(Region region)
        {
            return base.GetAll(x => x.AttachedRegions.Contains(region));
        }
    }
}