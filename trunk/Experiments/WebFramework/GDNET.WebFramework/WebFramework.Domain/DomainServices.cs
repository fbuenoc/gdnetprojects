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

        public static IEncryptionService Encryption
        {
            get { return _instance.GetEncryptionService(); }
        }

        public static IContentTypeService ContentType
        {
            get { return _instance.GetContentTypeService(); }
        }

        public static ITranslationService Translation
        {
            get { return _instance.GetTranslationService(); }
        }

        public static IFormatterService Formatter
        {
            get { return _instance.GetFormatterService(); }
        }

        protected abstract IEncryptionService GetEncryptionService();
        protected abstract IContentTypeService GetContentTypeService();
        protected abstract ITranslationService GetTranslationService();
        protected abstract IFormatterService GetFormatterService();
    }
}
