using GDNET.Common.Security.Services;
using WebFrameworkDomain.Services;

namespace WebFrameworkDomain.DefaultImpl
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

        protected abstract IEncryptionService GetEncryptionService();
        protected abstract IContentTypeService GetContentTypeService();
    }
}
