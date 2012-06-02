using GDNET.Common.Data;
using WebFramework.Domain.Widgets;

namespace WebFramework.Widgets.Domain.FileWg.Repositories
{
    public interface IFileContentRepository : IRepositoryBase<FileContent, long>, IWidgetEntityRepository<FileContent>
    {
    }
}