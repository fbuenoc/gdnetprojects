using GDNET.Common.Data;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Data.Common.Repositories;
using WebFramework.Data.Common.Specifications;
using WebFramework.Domain.DefaultImpl;
using WebFramework.Domain.Repositories.Common;

namespace WebFramework.Data.UnitTest
{
    public sealed class TestRepositories : DomainRepositories
    {
        private IApplicationRepository repositoryApplication = null;
        private IContentAttributeRepository repositoryContentAttribute = null;
        private IContentItemRepository repositoryContentItem = null;
        private IContentTypeRepository repositoryContentType = null;
        private ICultureRepository repositoryCulture = null;
        private IListValueRepository repositoryListValue = null;
        private ITemporaryRepository repositoryTemporary = null;
        private ITranslationRepository repositoryTranslation = null;
        private ISessionStrategy sessionStrategy = null;

        public TestRepositories(ISessionStrategy sessionStrategy)
        {
            this.sessionStrategy = sessionStrategy;
            base.Initialize(this);
        }

        public override IApplicationRepository GetApplicationRepository()
        {
            if (repositoryApplication == null)
            {
                repositoryApplication = new ApplicationRepository(this.sessionStrategy);
                repositoryApplication.Specification = new ApplicationSpecification();
            }
            return repositoryApplication;
        }

        public override IContentAttributeRepository GetContentAttributeRepository()
        {
            if (repositoryContentAttribute == null)
            {
                repositoryContentAttribute = new ContentAttributeRepository(this.sessionStrategy);
            }
            return repositoryContentAttribute;
        }

        public override IContentItemRepository GetContentItemRepository()
        {
            if (repositoryContentItem == null)
            {
                repositoryContentItem = new ContentItemRepository(this.sessionStrategy);
                repositoryContentItem.Specification = new ContentItemSpecification();
            }
            return repositoryContentItem;
        }

        public override IContentTypeRepository GetContentTypeRepository()
        {
            if (repositoryContentType == null)
            {
                repositoryContentType = new ContentTypeRepository(this.sessionStrategy);
                repositoryContentType.Specification = new ContentTypeSpecification();
            }
            return repositoryContentType;
        }

        public override ICultureRepository GetCultureRepository()
        {
            if (repositoryCulture == null)
            {
                repositoryCulture = new CultureRepository(this.sessionStrategy);
            }
            return repositoryCulture;
        }

        public override IListValueRepository GetRepositoryListValue()
        {
            if (repositoryListValue == null)
            {
                repositoryListValue = new ListValueRepository(this.sessionStrategy);
                repositoryListValue.Specification = new ListValueSpecification();
            }
            return repositoryListValue;
        }

        public override ITemporaryRepository GetTemporaryRepository()
        {
            if (repositoryTemporary == null)
            {
                repositoryTemporary = new TemporaryRepository(this.sessionStrategy);
                repositoryTemporary.Specification = new TemporarySpecification();
            }
            return repositoryTemporary;
        }

        public override ITranslationRepository GetTranslationRepository()
        {
            if (repositoryTranslation == null)
            {
                repositoryTranslation = new TranslationRepository(this.sessionStrategy);
            }
            return repositoryTranslation;
        }

        public override IRepositoryAssistant GetRepositoryAssistant()
        {
            return (IRepositoryAssistant)this.sessionStrategy;
        }
    }
}
