using GDNET.Common.Data;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Data.Common.Repositories;
using WebFramework.Data.Common.Specifications;
using WebFramework.Data.System.AdminRepositories;
using WebFramework.Data.System.Repositories;
using WebFramework.Domain;
using WebFramework.Domain.Repositories.Common;
using WebFramework.Domain.Repositories.System;
using WebFramework.Domain.System;

namespace WebFramework.NHibernate
{
    public sealed class FrameworkAdminRepositories : DomainRepositories
    {
        private ISessionStrategy sessionStrategy;

        public FrameworkAdminRepositories(ISessionStrategy sessionStrategy)
            : base()
        {
            this.sessionStrategy = sessionStrategy;
            base.Initialize(this);
        }

        protected override T GetWidgetRepositoryInternal<T>(Widget w)
        {
            return default(T);
        }

        protected override IApplicationRepository GetApplicationRepository()
        {
            IApplicationRepository repository = new ApplicationRepository(this.sessionStrategy);
            repository.Specification = new ApplicationSpecification();

            return repository;
        }

        protected override IContentAttributeRepository GetContentAttributeRepository()
        {
            IContentAttributeRepository repository = new ContentAttributeRepository(this.sessionStrategy);
            repository.Specification = new ContentAttributeSpecification();

            return repository;
        }

        protected override IContentItemRepository GetContentItemRepository()
        {
            IContentItemRepository repository = new ContentItemRepository(this.sessionStrategy);
            repository.Specification = new ContentItemSpecification();

            return repository;
        }

        protected override IContentTypeRepository GetContentTypeRepository()
        {
            IContentTypeRepository repository = new ContentTypeRepository(this.sessionStrategy);
            repository.Specification = new ContentTypeSpecification();

            return repository;
        }

        protected override ICultureRepository GetCultureRepository()
        {
            ICultureRepository repository = new CultureRepository(this.sessionStrategy);
            repository.Specification = new CultureSpecification();
            return repository;
        }

        protected override IListValueRepository GetRepositoryListValue()
        {
            IListValueRepository repository = new ListValueRepository(this.sessionStrategy);
            repository.Specification = new ListValueSpecification();
            return repository;
        }

        protected override ITemporaryRepository GetTemporaryRepository()
        {
            ITemporaryRepository repository = new TemporaryRepository(this.sessionStrategy);
            repository.Specification = new TemporarySpecification();
            return repository;
        }

        protected override ITranslationRepository GetTranslationRepository()
        {
            ITranslationRepository repository = new TranslationRepository(this.sessionStrategy);
            repository.Specification = new TranslationSpecification();

            return repository;
        }

        protected override IPageRepository GetPageRepository()
        {
            IPageRepository repository = new AdminPageRepository(this.sessionStrategy);
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

        protected override IRepositoryAssistant GetRepositoryAssistant()
        {
            return this.sessionStrategy;
        }
    }
}
