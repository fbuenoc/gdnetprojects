using GDNET.Common.Encryption;
using GDNET.Common.Security.Services;
using WebFramework.Domain.DefaultImpl;
using WebFramework.Domain.Services;

namespace WebFramework.NHibernate
{
    public sealed class InfrastructureServices : DomainServices
    {
        public InfrastructureServices()
        {
            base.Initialize(this);
        }

        protected override IEncryptionService GetEncryptionService()
        {
            IEncryptionService encryptionService = new EncryptionService();
            return encryptionService;
        }

        protected override IContentTypeService GetContentTypeService()
        {
            IContentTypeService contentTypeService = new ContentTypeService();
            return contentTypeService;
        }
    }
}
