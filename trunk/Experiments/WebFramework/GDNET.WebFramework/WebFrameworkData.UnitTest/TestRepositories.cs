using GDNET.Common.Data;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Data.Common.Repositories;
using WebFramework.Data.Common.Specifications;
using WebFramework.Data.System.Repositories;
using WebFramework.Domain;
using WebFramework.Domain.Repositories.Common;
using WebFramework.Domain.Repositories.System;

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

        protected override IApplicationRepository GetApplicationRepository()
        {
            if (repositoryApplication == null)
            {
                repositoryApplication = new ApplicationRepository(this.sessionStrategy);
                repositoryApplication.Specification = new ApplicationSpecification();
            }
            return repositoryApplication;
        }

        protected override IContentAttributeRepository GetContentAttributeRepository()
        {
            if (repositoryContentAttribute == null)
            {
                repositoryContentAttribute = new ContentAttributeRepository(this.sessionStrategy);
            }
            return repositoryContentAttribute;
        }

        protected override IContentItemRepository GetContentItemRepository()
        {
            if (repositoryContentItem == null)
            {
                repositoryContentItem = new ContentItemRepository(this.sessionStrategy);
                repositoryContentItem.Specification = new ContentItemSpecification();
            }
            return repositoryContentItem;
        }

        protected override IContentTypeRepository GetContentTypeRepository()
        {
            if (repositoryContentType == null)
            {
                repositoryContentType = new ContentTypeRepository(this.sessionStrategy);
                repositoryContentType.Specification = new ContentTypeSpecification();
            }
            return repositoryContentType;
        }

        protected override ICultureRepository GetCultureRepository()
        {
            if (repositoryCulture == null)
            {
                repositoryCulture = new CultureRepository(this.sessionStrategy);
            }
            return repositoryCulture;
        }

        protected override IListValueRepository GetRepositoryListValue()
        {
            if (repositoryListValue == null)
            {
                repositoryListValue = new ListValueRepository(this.sessionStrategy);
                repositoryListValue.Specification = new ListValueSpecification();
            }
            return repositoryListValue;
        }

        protected override ITemporaryRepository GetTemporaryRepository()
        {
            if (repositoryTemporary == null)
            {
                repositoryTemporary = new TemporaryRepository(this.sessionStrategy);
                repositoryTemporary.Specification = new TemporarySpecification();
            }
            return repositoryTemporary;
        }

        protected override ITranslationRepository GetTranslationRepository()
        {
            if (repositoryTranslation == null)
            {
                repositoryTranslation = new TranslationRepository(this.sessionStrategy);
            }
            return repositoryTranslation;
        }

        protected override IRepositoryAssistant GetRepositoryAssistant()
        {
            return (IRepositoryAssistant)this.sessionStrategy;
        }

        protected override IPageRepository GetPageRepository()
        {
            IPageRepository repository = new PageRepository(this.sessionStrategy);
            return repository;
        }

        protected override IWidgetRepository GetWidgetRepository()
        {
            IWidgetRepository repository = new WidgetRepository(this.sessionStrategy);
            return repository;
        }

        protected override IZoneRepository GetZoneRepository()
        {
            IZoneRepository repository = new ZoneRepository(this.sessionStrategy);
            return repository;
        }

        protected override T GetWidgetRepositoryInternal<T>(Domain.System.Widget w)
        {
            throw new global::System.NotImplementedException();
        }
    }
}
