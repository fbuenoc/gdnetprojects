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

        public static IRepositoryApplication Application
        {
            get { return _instance.GetRepositoryApplication(); }
        }

        public static IRepositoryContentAttribute ContentAttribute
        {
            get { return _instance.GetRepositoryContentAttribute(); }
        }

        public static IRepositoryContentItem ContentItem
        {
            get { return _instance.GetRepositoryContentItem(); }
        }

        public static IRepositoryContentType ContentType
        {
            get { return _instance.GetRepositoryContentType(); }
        }

        public static IRepositoryCulture Culture
        {
            get { return _instance.GetRepositoryCulture(); }
        }

        public static IRepositoryListValue ListValue
        {
            get { return _instance.GetRepositoryListValue(); }
        }

        public static IRepositoryTemporary Temporary
        {
            get { return _instance.GetRepositoryTemporary(); }
        }

        public static IRepositoryTranslation Translation
        {
            get { return _instance.GetRepositoryTranslation(); }
        }

        public static IRepositoryAssistant RepositoryAssistant
        {
            get { return _instance.GetRepositoryAssistant(); }
        }

        #region Abstract methods

        public abstract IRepositoryApplication GetRepositoryApplication();
        public abstract IRepositoryContentAttribute GetRepositoryContentAttribute();
        public abstract IRepositoryContentItem GetRepositoryContentItem();
        public abstract IRepositoryContentType GetRepositoryContentType();
        public abstract IRepositoryCulture GetRepositoryCulture();
        public abstract IRepositoryListValue GetRepositoryListValue();
        public abstract IRepositoryTemporary GetRepositoryTemporary();
        public abstract IRepositoryTranslation GetRepositoryTranslation();
        public abstract IRepositoryAssistant GetRepositoryAssistant();

        #endregion

    }
}
