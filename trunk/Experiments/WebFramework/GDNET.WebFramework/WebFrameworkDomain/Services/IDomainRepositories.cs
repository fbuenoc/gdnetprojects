using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkDomain.Services
{
    public interface IDomainRepositories
    {
        IRepositoryContentAttribute GetRepositoryContentAttribute();
        IRepositoryContentItem GetRepositoryContentItem();
        IRepositoryContentType GetRepositoryContentType();
        IRepositoryCulture GetRepositoryCulture();
        IRepositoryListValue GetRepositoryListValue();
        IRepositoryTranslation GetRepositoryTranslation();
        IRepositoryTemporary GetRepositoryTemporary();
    }
}
