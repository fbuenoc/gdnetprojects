using GDNET.Common.Security.Services;
using GDNET.Common.Services;
using WebFramework.Domain.Services;

namespace WebFramework.Domain
{
    public abstract class DomainServices
    {
        private static DomainServices _instance;

        protected void Initialize(DomainServices instance)
        {
            _instance = instance;
        }

        public static IContentTypeService ContentType
        {
            get { return _instance.GetContentTypeService(); }
        }

        public static IEncryptionService Encryption
        {
            get { return _instance.GetEncryptionService(); }
        }

        public static IFormatterService Formatter
        {
            get { return _instance.GetFormatterService(); }
        }

        public static IPageService Page
        {
            get { return _instance.GetPageService(); }
        }

        public static ITranslationService Translation
        {
            get { return _instance.GetTranslationService(); }
        }

        #region System

        public static IRegionService Region
        {
            get { return _instance.GetRegionService(); }
        }

        #endregion

        protected abstract IEncryptionService GetEncryptionService();
        protected abstract IContentTypeService GetContentTypeService();
        protected abstract ITranslationService GetTranslationService();
        protected abstract IFormatterService GetFormatterService();

        protected abstract IRegionService GetRegionService();
        protected abstract IPageService GetPageService();
    }
}
