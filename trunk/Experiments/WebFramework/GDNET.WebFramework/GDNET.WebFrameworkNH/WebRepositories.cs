using GDNET.Common.Data;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkData.Common.Repositories;
using WebFrameworkData.Common.Specifications;
using WebFrameworkDomain.Common.Repositories;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkNHibernate
{
    public sealed class WebRepositories : DomainRepositories
    {
        private ISessionStrategy sessionStrategy;

        public WebRepositories(ISessionStrategy sessionStrategy)
        {
            this.sessionStrategy = sessionStrategy;
            base.Initialize(this);
        }

        public override IRepositoryApplication GetRepositoryApplication()
        {
            IRepositoryApplication repositoryApplication = new RepositoryApplication(this.sessionStrategy);
            repositoryApplication.Specification = new SpecificationApplication();

            return repositoryApplication;
        }

        public override IRepositoryContentAttribute GetRepositoryContentAttribute()
        {
            return new RepositoryContentAttribute(this.sessionStrategy);
        }

        public override IRepositoryContentItem GetRepositoryContentItem()
        {
            IRepositoryContentItem repositoryContentItem = new RepositoryContentItem(this.sessionStrategy);
            repositoryContentItem.Specification = new SpecificationContentItem();

            return repositoryContentItem;
        }

        public override IRepositoryContentType GetRepositoryContentType()
        {
            IRepositoryContentType repositoryContentType = new RepositoryContentType(this.sessionStrategy);
            repositoryContentType.Specification = new SpecificationContentType();

            return repositoryContentType;
        }

        public override IRepositoryCulture GetRepositoryCulture()
        {
            return new RepositoryCulture(this.sessionStrategy);
        }

        public override IRepositoryListValue GetRepositoryListValue()
        {
            IRepositoryListValue repositoryListValue = new RepositoryListValue(this.sessionStrategy);
            repositoryListValue.Specification = new SpecificationListValue();
            return repositoryListValue;
        }

        public override IRepositoryTemporary GetRepositoryTemporary()
        {
            return new RepositoryTemporary(this.sessionStrategy);
        }

        public override IRepositoryTranslation GetRepositoryTranslation()
        {
            return new RepositoryTranslation(this.sessionStrategy);
        }

        public override IRepositoryAssistant GetRepositoryAssistant()
        {
            return (IRepositoryAssistant)this.sessionStrategy;
        }
    }
}
