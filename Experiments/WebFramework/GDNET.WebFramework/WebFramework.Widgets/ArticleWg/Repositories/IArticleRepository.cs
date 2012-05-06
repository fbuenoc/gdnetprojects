using GDNET.Common.Data;
using WebFramework.Domain.Widgets;
using WebFramework.Widgets.ArticleWg.Domain;

namespace WebFramework.Widgets.ArticleWg.Repositories
{
    public interface IArticleRepository : IRepositoryBase<Article, long>, IWidgetEntityRepository
    {
    }
}