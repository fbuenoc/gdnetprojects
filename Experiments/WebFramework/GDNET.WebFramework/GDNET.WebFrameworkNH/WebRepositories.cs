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
            IRepositoryApplication repositoryApplication = new RepositoryApplication(NHibernateHttpApplication.GetCurrentSession());
            repositoryApplication.Specification = new SpecificationApplication();

            return repositoryApplication;
        }

        public override IRepositoryContentAttribute GetRepositoryContentAttribute()
        {
            return new RepositoryContentAttribute(NHibernateHttpApplication.GetCurrentSession());
        }

        public override IRepositoryContentItem GetRepositoryContentItem()
        {
            IRepositoryContentItem repositoryContentItem = new RepositoryContentItem(NHibernateHttpApplication.GetCurrentSession());
            repositoryContentItem.Specification = new SpecificationContentItem();

            return repositoryContentItem;
        }

        public override IRepositoryContentType GetRepositoryContentType()
        {
            IRepositoryContentType repositoryContentType = new RepositoryContentType(NHibernateHttpApplication.GetCurrentSession());
            repositoryContentType.Specification = new SpecificationContentType();

            return repositoryContentType;
        }

        public override IRepositoryCulture GetRepositoryCulture()
        {
            return new RepositoryCulture(NHibernateHttpApplication.GetCurrentSession());
        }

        public override IRepositoryListValue GetRepositoryListValue()
        {
            IRepositoryListValue repositoryListValue = new RepositoryListValue(NHibernateHttpApplication.GetCurrentSession());
            repositoryListValue.Specification = new SpecificationListValue();
            return repositoryListValue;
        }

        public override IRepositoryTemporary GetRepositoryTemporary()
        {
            return new RepositoryTemporary(NHibernateHttpApplication.GetCurrentSession());
        }

        public override IRepositoryTranslation GetRepositoryTranslation()
        {
            return new RepositoryTranslation(NHibernateHttpApplication.GetCurrentSession());
        }
    }
}
