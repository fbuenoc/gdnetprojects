using GDNET.Common.Data;
using WebFramework.Domain.Widgets;

namespace WebFramework.Widgets.Domain.ArticleWg.Repositories
{
    public interface IArticleRepository : IRepositoryBase<Article, long>, IWidgetEntityRepository
    {
    }
}