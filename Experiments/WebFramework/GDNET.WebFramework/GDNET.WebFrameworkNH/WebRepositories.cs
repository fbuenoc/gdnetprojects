using GDNET.NHibernate.SessionManagers;
using WebFrameworkData.Common.Repositories;
using WebFrameworkData.Common.Specifications;
using WebFrameworkDomain.Common.Repositories;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkNHibernate
{
    public sealed class WebRepositories : DomainRepositories
    {
        public WebRepositories()
        {
            base.Initialize(this);
        }

        public override IRepositoryApplication GetRepositoryApplication()
        {
            IRepositoryApplication repositoryApplication = new RepositoryApplication(SessionManager.Instance.GetCurrentSession());
            repositoryApplication.Specification = new SpecificationApplication();

            return repositoryApplication;
        }

        public override IRepositoryContentAttribute GetRepositoryContentAttribute()
        {
            return new RepositoryContentAttribute(SessionManager.Instance.GetCurrentSession());
        }

        public override IRepositoryContentItem GetRepositoryContentItem()
        {
            IRepositoryContentItem repositoryContentItem = new RepositoryContentItem(SessionManager.Instance.GetCurrentSession());
            repositoryContentItem.Specification = new SpecificationContentItem();

            return repositoryContentItem;
        }

        public override IRepositoryContentType GetRepositoryContentType()
        {
            IRepositoryContentType repositoryContentType = new RepositoryContentType(SessionManager.Instance.GetCurrentSession());
            repositoryContentType.Specification = new SpecificationContentType();

            return repositoryContentType;
        }

        public override IRepositoryCulture GetRepositoryCulture()
        {
            return new RepositoryCulture(SessionManager.Instance.GetCurrentSession());
        }

        public override IRepositoryListValue GetRepositoryListValue()
        {
            IRepositoryListValue repositoryListValue = new RepositoryListValue(SessionManager.Instance.GetCurrentSession());
            repositoryListValue.Specification = new SpecificationListValue();
            return repositoryListValue;
        }

        public override IRepositoryTemporary GetRepositoryTemporary()
        {
            return new RepositoryTemporary(SessionManager.Instance.GetCurrentSession());
        }

        public override IRepositoryTranslation GetRepositoryTranslation()
        {
            return new RepositoryTranslation(SessionManager.Instance.GetCurrentSession());
        }
    }
}
