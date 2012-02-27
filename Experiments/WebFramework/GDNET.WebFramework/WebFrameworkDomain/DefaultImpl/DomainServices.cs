using GDNET.Common.Security.Services;

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

        protected abstract IEncryptionService GetEncryptionService();
    }
}
