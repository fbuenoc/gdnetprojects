using GDNET.Common.Data;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkData.Common.Repositories;
using WebFrameworkData.Common.Specifications;
using WebFrameworkDomain.Common.Repositories;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkData.UnitTest
{
    public sealed class TestRepositories : DomainRepositories
    {
        private IRepositoryApplication repositoryApplication = null;
        private IRepositoryContentAttribute repositoryContentAttribute = null;
        private IRepositoryContentItem repositoryContentItem = null;
        private IRepositoryContentType repositoryContentType = null;
        private IRepositoryCulture repositoryCulture = null;
        private IRepositoryListValue repositoryListValue = null;
        private IRepositoryTemporary repositoryTemporary = null;
        private IRepositoryTranslation repositoryTranslation = null;
        private ISessionStrategy sessionStrategy = null;

        public TestRepositories(ISessionStrategy sessionStrategy)
        {
            this.sessionStrategy = sessionStrategy;
            base.Initialize(this);
        }

        public override IRepositoryApplication GetRepositoryApplication()
        {
            if (repositoryApplication == null)
            {
                repositoryApplication = new RepositoryApplication(this.sessionStrategy);
                repositoryApplication.Specification = new SpecificationApplication();
            }
            return repositoryApplication;
        }

        public override IRepositoryContentAttribute GetRepositoryContentAttribute()
        {
            if (repositoryContentAttribute == null)
            {
                repositoryContentAttribute = new RepositoryContentAttribute(this.sessionStrategy);
            }
            return repositoryContentAttribute;
        }

        public override IRepositoryContentItem GetRepositoryContentItem()
        {
            if (repositoryContentItem == null)
            {
                repositoryContentItem = new RepositoryContentItem(this.sessionStrategy);
                repositoryContentItem.Specification = new SpecificationContentItem();
            }
            return repositoryContentItem;
        }

        public override IRepositoryContentType GetRepositoryContentType()
        {
            if (repositoryContentType == null)
            {
                repositoryContentType = new RepositoryContentType(this.sessionStrategy);
                repositoryContentType.Specification = new SpecificationContentType();
            }
            return repositoryContentType;
        }

        public override IRepositoryCulture GetRepositoryCulture()
        {
            if (repositoryCulture == null)
            {
                repositoryCulture = new RepositoryCulture(this.sessionStrategy);
            }
            return repositoryCulture;
        }

        public override IRepositoryListValue GetRepositoryListValue()
        {
            if (repositoryListValue == null)
            {
                repositoryListValue = new RepositoryListValue(this.sessionStrategy);
                repositoryListValue.Specification = new SpecificationListValue();
            }
            return repositoryListValue;
        }

        public override IRepositoryTemporary GetRepositoryTemporary()
        {
            if (repositoryTemporary == null)
            {
                repositoryTemporary = new RepositoryTemporary(this.sessionStrategy);
                repositoryTemporary.Specification = new SpecificationTemporary();
            }
            return repositoryTemporary;
        }

        public override IRepositoryTranslation GetRepositoryTranslation()
        {
            if (repositoryTranslation == null)
            {
                repositoryTranslation = new RepositoryTranslation(this.sessionStrategy);
            }
            return repositoryTranslation;
        }

        public override IRepositoryAssistant GetRepositoryAssistant()
        {
            return (IRepositoryAssistant)this.sessionStrategy;
        }
    }
}
