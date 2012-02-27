using GDNET.Common.Data;
using WebFrameworkDomain.Repositories.Common;

namespace WebFrameworkDomain.DefaultImpl
{
    public abstract class DomainRepositories
    {
        private static DomainRepositories _instance;

        protected void Initialize(DomainRepositories instance)
        {
            _instance = instance;
        }

        public static IApplicationRepository Application
        {
            get { return _instance.GetApplicationRepository(); }
        }

        public static IContentAttributeRepository ContentAttribute
        {
            get { return _instance.GetContentAttributeRepository(); }
        }

        public static IContentItemRepository ContentItem
        {
            get { return _instance.GetContentItemRepository(); }
        }

        public static IContentTypeRepository ContentType
        {
            get { return _instance.GetContentTypeRepository(); }
        }

        public static ICultureRepository Culture
        {
            get { return _instance.GetCultureRepository(); }
        }

        public static IListValueRepository ListValue
        {
            get { return _instance.GetRepositoryListValue(); }
        }

        public static ITemporaryRepository Temporary
        {
            get { return _instance.GetTemporaryRepository(); }
        }

        public static ITranslationRepository Translation
        {
            get { return _instance.GetTranslationRepository(); }
        }

        public static IRepositoryAssistant RepositoryAssistant
        {
            get { return _instance.GetRepositoryAssistant(); }
        }

        #region Abstract methods

        public abstract IApplicationRepository GetApplicationRepository();
        public abstract IContentAttributeRepository GetContentAttributeRepository();
        public abstract IContentItemRepository GetContentItemRepository();
        public abstract IContentTypeRepository GetContentTypeRepository();
        public abstract ICultureRepository GetCultureRepository();
        public abstract IListValueRepository GetRepositoryListValue();
        public abstract ITemporaryRepository GetTemporaryRepository();
        public abstract ITranslationRepository GetTranslationRepository();
        public abstract IRepositoryAssistant GetRepositoryAssistant();

        #endregion

    }
}
