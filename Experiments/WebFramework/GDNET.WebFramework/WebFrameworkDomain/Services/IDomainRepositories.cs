using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkDomain.Services
{
    public interface IDomainRepositories
    {
        IRepositoryApplication GetRepositoryApplication();
        IRepositoryContentAttribute GetRepositoryContentAttribute();
        IRepositoryContentItem GetRepositoryContentItem();
        IRepositoryContentType GetRepositoryContentType();
        IRepositoryCulture GetRepositoryCulture();
        IRepositoryListValue GetRepositoryListValue();
        IRepositoryTranslation GetRepositoryTranslation();
        IRepositoryTemporary GetRepositoryTemporary();
    }
}
