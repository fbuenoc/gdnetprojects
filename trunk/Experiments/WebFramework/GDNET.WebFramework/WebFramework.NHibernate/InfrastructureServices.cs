using GDNET.Common.Encryption;
using GDNET.Common.Security.Services;
using GDNET.Common.Services;
using WebFramework.Domain;
using WebFramework.Domain.Services;
using WebFramework.Services;

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

        protected override ITranslationService GetTranslationService()
        {
            return new TranslationService();
        }

        protected override IFormatterService GetFormatterService()
        {
            return new FormatterService();
        }
    }
}
