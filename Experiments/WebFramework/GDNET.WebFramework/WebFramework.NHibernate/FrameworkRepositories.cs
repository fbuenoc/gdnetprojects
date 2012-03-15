using GDNET.Common.Data;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Data.Common.Repositories;
using WebFramework.Data.Common.Specifications;
using WebFramework.Domain;
using WebFramework.Domain.Repositories.Common;

namespace WebFramework.NHibernate
{
    public sealed class FrameworkRepositories : DomainRepositories
    {
        private ISessionStrategy sessionStrategy;

        public FrameworkRepositories(ISessionStrategy sessionStrategy)
        {
            this.sessionStrategy = sessionStrategy;
            base.Initialize(this);
        }

        public override IApplicationRepository GetApplicationRepository()
        {
            IApplicationRepository repositoryApplication = new ApplicationRepository(this.sessionStrategy);
            repositoryApplication.Specification = new ApplicationSpecification();

            return repositoryApplication;
        }

        public override IContentAttributeRepository GetContentAttributeRepository()
        {
            IContentAttributeRepository contentAttributeRepository = new ContentAttributeRepository(this.sessionStrategy);
            contentAttributeRepository.Specification = new ContentAttributeSpecification();

            return contentAttributeRepository;
        }

        public override IContentItemRepository GetContentItemRepository()
        {
            IContentItemRepository repositoryContentItem = new ContentItemRepository(this.sessionStrategy);
            repositoryContentItem.Specification = new ContentItemSpecification();

            return repositoryContentItem;
        }

        public override IContentTypeRepository GetContentTypeRepository()
        {
            IContentTypeRepository repositoryContentType = new ContentTypeRepository(this.sessionStrategy);
            repositoryContentType.Specification = new ContentTypeSpecification();

            return repositoryContentType;
        }

        public override ICultureRepository GetCultureRepository()
        {
            ICultureRepository cultureRepository = new CultureRepository(this.sessionStrategy);
            cultureRepository.Specification = new CultureSpecification();
            return cultureRepository;
        }

        public override IListValueRepository GetRepositoryListValue()
        {
            IListValueRepository repositoryListValue = new ListValueRepository(this.sessionStrategy);
            repositoryListValue.Specification = new ListValueSpecification();
            return repositoryListValue;
        }

        public override ITemporaryRepository GetTemporaryRepository()
        {
            ITemporaryRepository temporaryRepository = new TemporaryRepository(this.sessionStrategy);
            temporaryRepository.Specification = new TemporarySpecification();
            return temporaryRepository;
        }

        public override ITranslationRepository GetTranslationRepository()
        {
            ITranslationRepository translationRepository = new TranslationRepository(this.sessionStrategy);
            translationRepository.Specification = new TranslationSpecification();
            return translationRepository;
        }

        public override IRepositoryAssistant GetRepositoryAssistant()
        {
            return this.sessionStrategy;
        }
    }
}
