using GDNET.Common.Data;
using WebFramework.Domain.Repositories.Common;
using WebFramework.Domain.Repositories.System;
using WebFramework.Domain.System;
using WebFramework.Domain.Widgets;

namespace WebFramework.Domain
{
    public abstract class DomainRepositories
    {
        protected static DomainRepositories _instance;

        protected void Initialize(DomainRepositories instance)
        {
            _instance = instance;
        }

        #region Common Repositories

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

        #endregion

        #region System Repositories

        public static IPageRepository Page
        {
            get { return _instance.GetPageRepository(); }
        }

        public static IWidgetRepository Widget
        {
            get { return _instance.GetWidgetRepository(); }
        }

        public static IZoneRepository Zone
        {
            get { return _instance.GetZoneRepository(); }
        }

        #endregion

        public static T GetWidgetRepository<T>(Widget w) where T : IWidgetEntityRepository
        {
            return _instance.GetWidgetRepositoryInternal<T>(w);
        }

        protected abstract T GetWidgetRepositoryInternal<T>(Widget w) where T : IWidgetEntityRepository;

        #region Abstract methods

        protected abstract IApplicationRepository GetApplicationRepository();
        protected abstract IContentAttributeRepository GetContentAttributeRepository();
        protected abstract IContentItemRepository GetContentItemRepository();
        protected abstract IContentTypeRepository GetContentTypeRepository();
        protected abstract ICultureRepository GetCultureRepository();
        protected abstract IListValueRepository GetRepositoryListValue();
        protected abstract ITemporaryRepository GetTemporaryRepository();
        protected abstract ITranslationRepository GetTranslationRepository();
        protected abstract IRepositoryAssistant GetRepositoryAssistant();

        protected abstract IPageRepository GetPageRepository();
        protected abstract IWidgetRepository GetWidgetRepository();
        protected abstract IZoneRepository GetZoneRepository();

        #endregion

    }
}
