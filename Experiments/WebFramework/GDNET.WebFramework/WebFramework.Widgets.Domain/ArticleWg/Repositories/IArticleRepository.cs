using System.Collections.Generic;
using GDNET.Common.Data;
using WebFramework.Domain.System;
using WebFramework.Domain.Widgets;

namespace WebFramework.Widgets.Domain.ArticleWg.Repositories
{
    public interface IArticleRepository : IRepositoryBase<Article, long>, IWidgetEntityRepository
    {
        IList<Article> GetAllByRegion(Region region);
    }
}